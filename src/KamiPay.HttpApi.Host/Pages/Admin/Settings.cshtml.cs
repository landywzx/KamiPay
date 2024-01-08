using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KamiPay.Pages.Admin;

[Authorize]
public class SettingsModel : PageModel
{
    public void OnGet()
    {
    }
}