using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace qa.EntityFrameworkCore
{
    [DependsOn(
        typeof(qaEntityFrameworkCoreModule)
        )]
    public class qaEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<qaMigrationsDbContext>();
        }
    }
}
