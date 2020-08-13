using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace qa.Data
{
    /* This is used if database provider does't define
     * IqaDbSchemaMigrator implementation.
     */
    public class NullqaDbSchemaMigrator : IqaDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}