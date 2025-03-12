using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuiChen.AbpPro.IP.Location
{
    public class AbpIPLocationResolveOptions
    {
        [NotNull]
        public List<IIPLocationResolveContributor> IPLocationResolvers { get; }

        public AbpIPLocationResolveOptions()
        {
            IPLocationResolvers = new List<IIPLocationResolveContributor>();
        }

    }
}
