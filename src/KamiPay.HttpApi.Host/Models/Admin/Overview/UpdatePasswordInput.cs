using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;

namespace KamiPay.Models.Admin.Overview;

public class UpdatePasswordInput
{
    [Required(ErrorMessage = "CurrentPasswordRequired")]
    [Display(Name = nameof(CurrentPassword))]
    [DataType(DataType.Password)]
    [DisableAuditing]
    public string CurrentPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "NewPasswordRequired")]
    [Display(Name = nameof(NewPassword))]
    [DataType(DataType.Password)]
    [DisableAuditing]
    public string NewPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "ConfirmPasswordRequired")]
    [Compare(nameof(NewPassword), ErrorMessage = "PasswordNotMatched")]
    [Display(Name = nameof(ConfirmPassword))]
    [DataType(DataType.Password)]
    [DisableAuditing]
    public string ConfirmPassword { get; set; } = string.Empty;
}