using Volo.Abp.Modularity;

namespace KamiPay;

/* Inherit from this class for your domain layer tests. */
public abstract class KamiPayDomainTestBase<TStartupModule> : KamiPayTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
