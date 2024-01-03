using Volo.Abp.Settings;

namespace KamiPay.Settings;

public class KamiPaySettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(KamiPaySettings.MySetting1));
    }
}
