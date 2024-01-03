using Volo.Abp.Modularity;

namespace KamiPay;

[DependsOn(
    typeof(KamiPayApplicationModule),
    typeof(KamiPayDomainTestModule)
)]
public class KamiPayApplicationTestModule : AbpModule
{

}
