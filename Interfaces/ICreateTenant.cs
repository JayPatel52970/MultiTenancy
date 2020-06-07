using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MultiTenancyAngular
{
    public interface ICreateTenant
    {
        Tenant CreateTenant(string tenantName, string hostUrl);

    }
}
