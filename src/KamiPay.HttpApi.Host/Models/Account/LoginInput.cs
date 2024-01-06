using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace KamiPay.Models.Account;

public class LoginInput
{
    [Required(ErrorMessage = "UserNameOrEmailAddressRequired")]
    [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxEmailLength))]
    [Display(Name = nameof(UserNameOrEmailAddress))]
    public string UserNameOrEmailAddress { get; set; } = string.Empty;

    [Required(ErrorMessage = "PasswordRequired")]
    [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
    [Display(Name =nameof(Password))]
    [DataType(DataType.Password)]
    [DisableAuditing]
    public string Password { get; set; } = string.Empty;

    [Display(Name =nameof(RememberMe))]
    public bool RememberMe { get; set; }
}