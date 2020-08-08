using qa.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace qa.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(qaEntityFrameworkCoreDbMigrationsModule),
        typeof(qaApplicationContractsModule)
        )]
    public class qaDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
