using System;
using System.Collections.Generic;
using System.Text;
using KamiPay.Localization;
using Volo.Abp.Application.Services;

namespace KamiPay;

/* Inherit your application services from this class.
 */
public abstract class KamiPayAppService : ApplicationService
{
    protected KamiPayAppService()
    {
        LocalizationResource = typeof(KamiPayResource);
    }
}
