using Volo.Abp.Modularity;

namespace qa
{
    [DependsOn(
        typeof(qaApplicationModule),
        typeof(qaDomainTestModule)
        )]
    public class qaApplicationTestModule : AbpModule
    {

    }
}