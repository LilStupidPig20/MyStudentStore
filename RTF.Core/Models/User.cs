using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTF.Core.Models;

[Table("Users")]
public record User : IDataModel
{
    [Column("Id")]
    [Key]
    public Guid Id { get; set; }
    
    [Column("FirstName")]
    [StringLength(40)]
    [Required]
    public string FirstName { get; set; }
    
    [Column("LastName")]
    [StringLength(40)]
    [Required]
    public string LastName { get; set; }
    
    [Column("Email")]
    [StringLength(100)]
    [Required]
    public string Email { get; set; }
    
    [Column("Password")]
    [StringLength(255)]
    [Required]
    public string Password { get; set; }
    
    [Column("Group")]
    [StringLength(20)]
    public string Group { get; set; }
}