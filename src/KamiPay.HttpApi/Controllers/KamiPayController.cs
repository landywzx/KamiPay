using KamiPay.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace KamiPay.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class KamiPayController : AbpControllerBase
{
    protected KamiPayController()
    {
        LocalizationResource = typeof(KamiPayResource);
    }
}
