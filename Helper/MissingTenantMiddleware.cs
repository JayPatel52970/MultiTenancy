using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenancyAngular
{
    public class MissingTenantMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string missingTenantUrl;

        public MissingTenantMiddleware(RequestDelegate next, string missingTenantUrl)
        {
            this.next = next;
            this.missingTenantUrl = missingTenantUrl;
        }

        public async Task Invoke(HttpContext httpContext, ITenantProvider tenantProvider)
        {
            if (tenantProvider.GetTenant() == null)
            {
                httpContext.Response.Redirect(missingTenantUrl);
                return;
            }

            await next.Invoke(httpContext);
        }
    }
}
