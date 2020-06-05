using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenancyAngular
{
    public class SqlTenantProvider : ITenantProvider
    {
        private readonly ITenantResolution tenantResolution;
        private readonly CatelogDbContext catelogDbContext;

        public SqlTenantProvider(ITenantResolution tenantResolution,CatelogDbContext catelogDbContext)
        {
            this.tenantResolution = tenantResolution;
            this.catelogDbContext = catelogDbContext;
        }

        public Tenant GetTenant()
        {
            string tenantName = tenantResolution.GetTenantHost();

            Tenant tenant = catelogDbContext.tenants.Find(tenantName);

            return tenant;
        }
    }
}
