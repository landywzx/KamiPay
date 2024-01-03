using KamiPay.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace KamiPay.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(KamiPayEntityFrameworkCoreModule),
    typeof(KamiPayApplicationContractsModule)
    )]
public class KamiPayDbMigratorModule : AbpModule
{
}
