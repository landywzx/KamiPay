using KamiPay.Samples;
using Xunit;

namespace KamiPay.EntityFrameworkCore.Applications;

[Collection(KamiPayTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<KamiPayEntityFrameworkCoreTestModule>
{

}
