using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Identity;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace KamiPay.Pages.Account;

public class LogoutModel(
    SignInManager<IdentityUser> signInManager,
    IdentitySecurityLogManager identitySecurityLogManager) : PageModel
{
    public async Task<IActionResult> OnGetAsync()
    {
        await identitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
        {
            Identity = IdentitySecurityLogIdentityConsts.Identity,
            Action = IdentitySecurityLogActionConsts.Logout,
        });

        await signInManager.SignOutAsync();

        return Redirect("/Account/Login");
    }
}