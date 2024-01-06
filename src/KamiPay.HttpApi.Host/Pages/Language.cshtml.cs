using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KamiPay.Pages;

public class LanguageModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Culture { get; set; } = string.Empty;

    [BindProperty(SupportsGet = true)]
    public string ReturnUrl { get; set; } = string.Empty;

    public IActionResult OnGet()
    {
        Response.Cookies.Append(
            key: CookieRequestCultureProvider.DefaultCookieName,
            value: CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(Culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

        return LocalRedirect(ReturnUrl);
    }
}