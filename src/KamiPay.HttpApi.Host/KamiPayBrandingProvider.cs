using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace KamiPay;

[Dependency(ReplaceServices = true)]
public class KamiPayBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "KamiPay";
}
