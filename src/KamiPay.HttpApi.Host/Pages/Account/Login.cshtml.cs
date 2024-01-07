using KamiPay.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.Account.Settings;
using Volo.Abp.Identity;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Settings;
using Volo.Abp.Users;
using Volo.Abp.Validation;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace KamiPay.Pages.Account;

public class LoginModel(
    SignInManager<IdentityUser> signInManager,
    IStringLocalizer<LoginModel> localizer,
    IdentitySecurityLogManager identitySecurityLogManager,
    IdentityUserManager userManager,
    ISettingProvider settingProvider,
    ICurrentUser currentUser) : PageModel
{
    protected IStringLocalizer L { get; } = localizer;

    [BindProperty]
    public LoginInput Input { get; set; } = new();

    public IActionResult OnGet()
    {
        if (currentUser.IsAuthenticated)
        {
            return RedirectToPage("/Admin/Overview");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await CheckLocalLoginAsync();
        await ReplaceEmailToUsernameOfInputIfNeeds();

        var signInResult = await signInManager.PasswordSignInAsync(
            userName: Input.UserNameOrEmailAddress,
            password: Input.Password,
            isPersistent: Input.RememberMe,
            lockoutOnFailure: true);

        await identitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
        {
            Identity = IdentitySecurityLogIdentityConsts.Identity,
            Action = signInResult.ToIdentitySecurityLogAction(),
            UserName = Input.UserNameOrEmailAddress
        });

        if (signInResult.Succeeded)
        {
            return Redirect("/Admin/Overview");
        }

        if (signInResult.IsLockedOut)
        {
            ModelState.AddModelError("Input.Password", L["LockedOut"]);
            return Page();
        }

        if (signInResult.RequiresTwoFactor)
        {
            ModelState.AddModelError("Input.Password", L["RequiresTwoFactor"]);
            return Page();
        }

        if (signInResult.IsNotAllowed)
        {
            ModelState.AddModelError("Input.Password", L["NotAllowed"]);
            return Page();
        }

        ModelState.AddModelError("Input.Password", L["InvalidUsernameOrPassword"]);

        return Page();
    }


    protected virtual async Task ReplaceEmailToUsernameOfInputIfNeeds()
    {
        if (!ValidationHelper.IsValidEmailAddress(Input.UserNameOrEmailAddress))
        {
            return;
        }

        var userByUsername = await userManager.FindByNameAsync(Input.UserNameOrEmailAddress);
        if (userByUsername != null)
        {
            return;
        }

        var userByEmail = await userManager.FindByEmailAsync(Input.UserNameOrEmailAddress);
        if (userByEmail == null)
        {
            return;
        }

        Input.UserNameOrEmailAddress = userByEmail.UserName;
    }

    protected virtual async Task CheckLocalLoginAsync()
    {
        if (!await settingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin))
        {
            throw new UserFriendlyException("LocalLoginDisabledMessage");
        }
    }
}