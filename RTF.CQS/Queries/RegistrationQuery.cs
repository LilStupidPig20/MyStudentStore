using System.ComponentModel.DataAnnotations;
using RTF.CQS.Abstractions;

namespace RTF.CQS.Queries;

public class RegistrationQuery : Query<bool>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Group { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}