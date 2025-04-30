using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using VoloAbpIdentityEntityFrameworkCoreModule = Volo.Abp.Identity.EntityFrameworkCore.AbpIdentityEntityFrameworkCoreModule;

namespace RuiChen.AbpPro.Identity
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(VoloAbpIdentityEntityFrameworkCoreModule)
        )]
    public class AbpIdentityEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<IdentityDbContext>(options =>
            {
                options.AddRepository<IdentityRole, EfCoreIdentityRoleRepository>();
                options.AddRepository<IdentityUser, EfCoreIdentityUserRepository>();
                options.AddRepository<IdentitySession, EfCoreIdentitySessionRepository>();
                options.AddRepository<OrganizationUnit, EfCoreOrganizationUnitRepository>();
            });
        }
    }
}
