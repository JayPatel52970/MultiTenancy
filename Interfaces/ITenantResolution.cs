using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenancyAngular
{
    public interface ITenantResolution
    {
        string GetTenantHost();

    }
}
