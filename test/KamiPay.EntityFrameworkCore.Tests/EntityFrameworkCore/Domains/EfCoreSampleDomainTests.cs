using KamiPay.Samples;
using Xunit;

namespace KamiPay.EntityFrameworkCore.Domains;

[Collection(KamiPayTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<KamiPayEntityFrameworkCoreTestModule>
{

}
