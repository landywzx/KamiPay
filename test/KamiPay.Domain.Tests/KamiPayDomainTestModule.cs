using Volo.Abp.Modularity;

namespace KamiPay;

[DependsOn(
    typeof(KamiPayDomainModule),
    typeof(KamiPayTestBaseModule)
)]
public class KamiPayDomainTestModule : AbpModule
{

}
