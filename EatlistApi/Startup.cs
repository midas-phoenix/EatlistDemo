using EatlistApi.Hubs;
using EatlistDAL;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EatlistApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<EatlistDAL.Models.ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //var policy = new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy();
            //policy.Headers.Add("*");
            //policy.Methods.Add("*");
            //policy.Origins.Add("*");
            //policy.SupportsCredentials = true;

            //services.AddCors(x => x.AddPolicy("corsGlobalPolicy", policy));

            //var guestPolicy = new AuthorizationPolicyBuilder()
            //    .RequireClaim("scope", "oidcdemomobile")
            //    .Build();

            services.AddCors(options =>
            {
                options.AddPolicy("default", policyy =>
                {
                    policyy.WithOrigins(Configuration["ClientAddress"])
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    policyy.WithOrigins("file://")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                    policyy.AllowCredentials();
                });

            });


            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler
            {
                InboundClaimTypeMap = new Dictionary<string, string>()
            };

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = Configuration["IdentityServerAddress"],
                ValidAudience = "oidcdemomobile",
                AuthenticationType = JwtBearerDefaults.AuthenticationScheme,
                
        };
            //*******************************
            /*************SwashBuckle*********************/
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "EatList API", Version = "v1" });
            });
            /******************************************/
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = Configuration["IdentityServerAddress"];
                o.Audience = "oidcdemomobile";
                o.RequireHttpsMetadata = false;
                //o.IncludeErrorDetails = true;
                //o.SaveToken = true;
                o.SecurityTokenValidators.Add(jwtSecurityTokenHandler);
                o.TokenValidationParameters = tokenValidationParameters;
                o.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if ((context.Request.Path.Value.StartsWith("/Ehub")
                           )
                            && context.Request.Query.TryGetValue("token", out StringValues token)
                        )
                        {
                            context.Token = token;
                        }

                        return Task.CompletedTask;
                    }//,
                    //OnAuthenticationFailed = context =>
                    //{
                    //    var te = context.Exception;
                    //    return Task.CompletedTask;
                    //}
                };
            });
            

            services.AddScoped<IUnitOfWork, HttpUnitOfWork>();
            services.AddMvc();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/ErrorTrace-{Date}.txt");

            /*******SwashBucle************/
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseCors("corsGlobalPolicy");
            app.UseCors("default");
            app.UseSignalR(routes =>
            {
                routes.MapHub<EatlistHub>("/Ehub");
            });

            app.UseAuthentication();

            app.UseMvc();

        }
    }
}
