using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Users;

namespace KamiPay.Pages;

public class IndexModel(ICurrentUser currentUser) : PageModel
{
    public IActionResult OnGet()
    {
        if (currentUser.IsAuthenticated)
        {
            return Page();
        }

        return Redirect("Account/Login");
    }
}