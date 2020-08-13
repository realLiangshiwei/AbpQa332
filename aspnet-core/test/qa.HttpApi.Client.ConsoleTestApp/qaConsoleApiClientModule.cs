using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace qa.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(qaHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class qaConsoleApiClientModule : AbpModule
    {
        
    }
}
