using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenancyAngular.Implementation
{
    public class LocalTenantCreation : ICreateTenant
    {
        private readonly CatelogDbContext catelogDbContext;

        public LocalTenantCreation(CatelogDbContext catelogDbContext)
        {
            this.catelogDbContext = catelogDbContext;
        }

        public Tenant CreateTenant(string tenantName, string hostUrl)
        {
            Tenant tenant = new Tenant
            {
                Name = tenantName,
                HostUrl = hostUrl,
                DbConnectionString = $"Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = {tenantName}; Integrated Security = True",
                StorageConnectionString = "",
                isActive = 1
            };

            catelogDbContext.tenants.Add(tenant);

            return tenant;
        }
    }
}
