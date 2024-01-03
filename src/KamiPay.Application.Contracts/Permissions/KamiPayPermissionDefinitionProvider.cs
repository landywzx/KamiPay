using KamiPay.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace KamiPay.Permissions;

public class KamiPayPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(KamiPayPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(KamiPayPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<KamiPayResource>(name);
    }
}
