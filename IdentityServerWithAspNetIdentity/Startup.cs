using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using IdentityServer4.Services;
//using EatListDataService.DataBase;
using IdentityServerWithAspNetIdentity.Services;
using Microsoft.Extensions.Logging;
using IdentityServerWithAspNetIdentity.Extensions;
using EatlistDAL;
using EatlistDAL.Models;

namespace IdentityServerWithAspNetIdentity
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
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // example of setting options
                options.Tokens.ChangePhoneNumberTokenProvider = "Phone";

                // password settings chosen due to NIST SP 800-63
                options.Password.RequiredLength = 8; // personally i'd prefer to see 10+
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            //add services to configureservices pipeline
           // services.AddAuthentication("Bearer")
           //.AddIdentityServerAuthentication(options =>
           //{
           //    options.Authority = "http://localhost:5000";
           //    options.RequireHttpsMetadata = false;

           //    options.ApiName = "api1";
           //});

            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:5003")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
                options.AddPolicy("React", policy =>
                {
                    policy.WithOrigins("http://localhost:51540")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
                options.AddPolicy("ReactStandAlone", policy =>
                {
                    policy.WithOrigins("http://localhost:53684")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients(Configuration))
                .AddAspNetIdentity<ApplicationUser>();
            //.AddProfileService<IdentityWithAdditionalClaimsProfileService>();
            //.AddConfigurationStore(options =>
            //{
            //    options.ConfigureDbContext = builder =>
            //        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            //            sql => sql.MigrationsAssembly(migrationsAssembly));
            //})
            //// this adds the operational data from DB (codes, tokens, consents)
            //.AddOperationalStore(options =>
            //{
            //    options.ConfigureDbContext = builder =>
            //        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            //            sql => sql.MigrationsAssembly(migrationsAssembly));

            //    // this enables automatic token cleanup. this is optional.
            //    options.EnableTokenCleanup = true;
            //    options.TokenCleanupInterval = 30;
            //});

            services.AddTransient<IProfileService, IdentityWithAdditionalClaimsProfileService>();
            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "998042782978-s07498t8i8jas7npj4crve1skpromf37.apps.googleusercontent.com";
                options.ClientSecret = "HsnwJri_53zn7VcO1Fm7THBb";
            });
            services.AddAuthentication().AddTwitter(twitterOptions =>
            {
                twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"];
                twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //New logger 
            loggerFactory.AddFile("Logs/myapp-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // app.UseAuthentication(); // not needed, since UseIdentityServer adds the authentication middleware
            app.UseIdentityServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
