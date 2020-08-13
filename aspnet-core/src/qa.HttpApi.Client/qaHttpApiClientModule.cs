using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Saas.Host;

namespace qa
{
    [DependsOn(
        typeof(qaApplicationContractsModule),
        typeof(AbpAccountHttpApiClientModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule),
        typeof(SaasHostHttpApiClientModule),
        typeof(AbpFeatureManagementHttpApiClientModule)
    )]
    [DependsOn(typeof(SaasHostHttpApiClientModule))]
    public class qaHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(qaApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
