using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenancyAngular
{
    public class HostUrlTenantResolution : ITenantResolution
    {
        private readonly string _host;

        public HostUrlTenantResolution(IHttpContextAccessor accessor)
        {
            _host = accessor.HttpContext.Request.Host.ToString();

        }
        public string GetTenantHost()
        {
            string host = _host;

            var nodes = host.Split('.');
            int startNode = 0;
            if (nodes[0] == "www") startNode = 1;

            return string.Format("{0}", nodes[startNode]);
        }
    }
}
