using qa.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace qa
{
    [DependsOn(
        typeof(qaEntityFrameworkCoreTestModule)
        )]
    public class qaDomainTestModule : AbpModule
    {

    }
}