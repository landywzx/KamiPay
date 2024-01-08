using KamiPay.Models.Admin.Overview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KamiPay.Pages.Admin;

[Authorize]
public class OverviewModel : PageModel
{
    public UpdateProfileInput UpdateProfileInput { get; set; } = new();

    public UpdatePasswordInput UpdatePasswordInput { get; set; } = new();

    public void OnGet()
    {
    }
}