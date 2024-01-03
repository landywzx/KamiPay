using Volo.Abp.Modularity;

namespace KamiPay;

public abstract class KamiPayApplicationTestBase<TStartupModule> : KamiPayTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
