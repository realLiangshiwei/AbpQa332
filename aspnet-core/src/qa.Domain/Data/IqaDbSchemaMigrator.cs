using System.Threading.Tasks;

namespace qa.Data
{
    public interface IqaDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
