using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuiChen.AbpPro.IP.Location
{
    public interface IIPLocationResolveContributor
    {
        string Name { get; }

        Task ResolveAsync(IIPLocationResolveContext context);
    }

}
