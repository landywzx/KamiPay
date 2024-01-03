using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace KamiPay.Data;

/* This is used if database provider does't define
 * IKamiPayDbSchemaMigrator implementation.
 */
public class NullKamiPayDbSchemaMigrator : IKamiPayDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
