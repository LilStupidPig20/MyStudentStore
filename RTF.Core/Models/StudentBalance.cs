using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTF.Core.Models;

[Table("StudentBalance")]
public record StudentBalance : DataModel
{
    [Column("UserId")]
    public Guid UserId { get; set; }
    
    [Column("Balance")]
    public double Balance { get; set; }
}