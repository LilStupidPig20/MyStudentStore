using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace RTF.Core.Models;

[Table("Admins")]
public record Admin : User
{
    [Column("SuperRules")]
    public bool SuperRules { get; set; }
}