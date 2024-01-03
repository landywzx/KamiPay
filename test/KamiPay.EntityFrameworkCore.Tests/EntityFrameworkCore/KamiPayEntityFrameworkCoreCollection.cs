using Xunit;

namespace KamiPay.EntityFrameworkCore;

[CollectionDefinition(KamiPayTestConsts.CollectionDefinitionName)]
public class KamiPayEntityFrameworkCoreCollection : ICollectionFixture<KamiPayEntityFrameworkCoreFixture>
{

}
