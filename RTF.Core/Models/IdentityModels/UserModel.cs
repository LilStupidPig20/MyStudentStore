using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTF.Core.Models.IdentityModels;

public abstract record UserModel : DataModel
{
    [Column("FirstName")]
    [StringLength(40)]
    [Required]
    public string FirstName { get; set; }
    
    [Column("LastName")]
    [StringLength(40)]
    [Required]
    public string LastName { get; set; }
    
    // [Column("Email")]
    // [StringLength(100)]
    // [Required]
    // public string Email { get; set; }
    //
    // [Column("Password")]
    // [StringLength(255)]
    // [Required]
    // public string Password { get; set; }
}