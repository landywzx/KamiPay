using KamiPay.Models.Admin.Overview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.Account;

namespace KamiPay.Pages.Admin;

[Authorize]
public class OverviewModel(IProfileAppService profileAppService, IStringLocalizer<OverviewModel> localizer) : PageModel
{
    protected IStringLocalizer<OverviewModel> L { get; } = localizer;

    public UpdateProfileInput UpdateProfileInput { get; set; } = new();

    public UpdatePasswordInput UpdatePasswordInput { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        var profile = await profileAppService.GetAsync();

        UpdateProfileInput.UserName = profile.UserName;
        UpdateProfileInput.Email = profile.Email;
        UpdateProfileInput.Name = profile.Name;
        UpdateProfileInput.Surname = profile.Surname;
        UpdateProfileInput.PhoneNumber = profile.PhoneNumber;
        UpdateProfileInput.ConcurrencyStamp = profile.ConcurrencyStamp;

        return Page();
    }

    public async Task<IActionResult> OnPostUpdateProfileAsync(UpdateProfileInput updateProfileInput)
    {
        return await OnGetAsync();
    }

    public async Task<IActionResult> OnPostChangePasswordAsync(UpdatePasswordInput updatePasswordInput)
    {
        if (!ModelState.IsValid)
        {
            return await OnGetAsync();
        }

        try
        {
            await profileAppService.ChangePasswordAsync(new ChangePasswordInput
            {
                CurrentPassword = updatePasswordInput.CurrentPassword,
                NewPassword = updatePasswordInput.NewPassword,
            });

            return Redirect("/Account/Logout");
        }
        catch (BusinessException exception)
        {
            if (exception.Code?.EndsWith("PasswordMismatch") ?? false)
            {
                ModelState.AddModelError("UpdatePasswordInput.CurrentPassword", L["PasswordMismatch"]);
            }
            else
            {
                ModelState.AddModelError("UpdatePasswordInput.NewPassword", L["PasswordDoesNotMeetRequirements"]);
            }
        }

        return await OnGetAsync();
    }
}