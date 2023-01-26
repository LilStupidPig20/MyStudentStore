using Microsoft.AspNetCore.Identity;

namespace RTF.Core.Models.IdentityModels;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Group { get; set; }
}