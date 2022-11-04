using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTF.Core.Models;

[Table("Students")]
public record Student : User
{
    [Column("Score")]
    [MaxLength(20)]
    public double Score { get; set; }
    
    [Column("RegisterDate")]
    public DateTime RegisterDate { get; set; }
    
    [Column("LastLogin")]
    public DateTime LastLogin { get; set; }
    
    [Column("Group")]
    [StringLength(20)]
    public string Group { get; set; }
}