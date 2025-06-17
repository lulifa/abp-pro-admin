using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.JQuery;
using Volo.Abp.Modularity;

namespace RuiChen.Admin.HttpApi.Host.Bundling;

[DependsOn(typeof(JQueryScriptContributor))]
public class SingleGlobalScriptContributor : BundleContributor
{
    public override Task ConfigureBundleAsync(BundleConfigurationContext context)
    {
        context.Files.Add("/scripts/abp-wrapper.js");

        return Task.CompletedTask;
    }
}