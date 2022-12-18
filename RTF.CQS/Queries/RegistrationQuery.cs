using System.ComponentModel.DataAnnotations;
using RTF.CQS.Abstractions;

namespace RTF.CQS.Queries;

public class RegistrationQuery : Query<bool>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Group { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}