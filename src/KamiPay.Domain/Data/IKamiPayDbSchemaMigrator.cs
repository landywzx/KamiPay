using System.Threading.Tasks;

namespace KamiPay.Data;

public interface IKamiPayDbSchemaMigrator
{
    Task MigrateAsync();
}
