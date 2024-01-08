using System.ComponentModel.DataAnnotations;

namespace KamiPay.Models.Admin.Overview;

public class UpdateProfileInput
{
    [Required(ErrorMessage = "UserNameRequired")]
    [Display(Name = nameof(UserName))]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "EmailRequired")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = nameof(Email))]
    public string Email { get; set; } = string.Empty;

    [Display(Name = nameof(Name))]
    public string Name { get; set; } = string.Empty;

    [Display(Name = nameof(Surname))]
    public string Surname { get; set; } = string.Empty;

    [Display(Name = nameof(PhoneNumber))]
    public string PhoneNumber { get; set; } = string.Empty;

    public string ConcurrencyStamp { get; set; } = string.Empty;
}