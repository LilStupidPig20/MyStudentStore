using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTF.Core.Models.IdentityModels;

[Table("Students")]
public record Student : UserModel
{
    [Column("RegisterDate")]
    public DateTime RegisterDate { get; set; }
    
    [Column("LastLogin")]
    public DateTime LastLogin { get; set; }
    
    [Column("Group")]
    [StringLength(20)]
    public string Group { get; set; }
}