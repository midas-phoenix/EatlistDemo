using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EatlistDAL
{
    public class HttpUnitOfWork : UnitOfWork
    {
        public HttpUnitOfWork(ApplicationDbContext context, ILogger<dynamic> log) : base(context, log)
        {
            
        }

        //public HttpUnitOfWork(ApplicationDbContext context, ILogger<dynamic> log, IHttpContextAccessor httpAccessor) : base(context, log)
        //{
        //    context.CurrentUserId = httpAccessor.HttpContext.User.FindFirst(OpenIdConnectConstants.Claims.Subject)?.Value?.Trim();
        //}
    }
}
