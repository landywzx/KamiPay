using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KamiPay.Pages.Admin;

[Authorize]
public class OverviewModel : PageModel
{
    public void OnGet()
    {
    }
}