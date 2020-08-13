using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Saas.Host;

namespace qa
{
    [DependsOn(
        typeof(qaApplicationContractsModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(SaasHostHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule)
        )]
    public class qaHttpApiModule : AbpModule
    {
        
    }
}
