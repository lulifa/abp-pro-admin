using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Threading;

namespace RuiChen.Platform
{
    [DependsOn(
        typeof(AbpEventBusModule),
        typeof(PlatformDomainSharedModule))]
    public class PlatformDomainModule : AbpModule
    {
        private static readonly OneTimeRunner OneTimeRunner = new();
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<PlatformDomainModule>();

            Configure<DataItemMappingOptions>(options =>
            {
                options.SetDefaultMapping();
            });

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<PlatformDomainMappingProfile>(validate: true);
            });

            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.EtoMappings.Add<Layout, LayoutEto>(typeof(PlatformDomainModule));

                options.EtoMappings.Add<Menu, MenuEto>(typeof(PlatformDomainModule));
                options.EtoMappings.Add<UserMenu, UserMenuEto>(typeof(PlatformDomainModule));
                options.EtoMappings.Add<RoleMenu, RoleMenuEto>(typeof(PlatformDomainModule));

            });

        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            //https://abp.io/docs/latest/framework/architecture/modularity/extending/module-entity-extensions
            OneTimeRunner.Run(() =>
            {
                ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                PlatformModuleExtensionConsts.ModuleName,
                PlatformModuleExtensionConsts.EntityNames.Route,
                typeof(Route));
            });
        }
    }
}
