using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace RuiChen.AbpPro.IP.Location
{
    public interface IIPLocationResolveContext : IServiceProviderAccessor
    {
        string IpAddress { get; }

        IPLocation? Location { get; set; }

        bool Handled { get; set; }
    }
}
