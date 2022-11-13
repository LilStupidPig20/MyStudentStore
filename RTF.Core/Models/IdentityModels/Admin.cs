using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using RTF.Core.Models.IdentityModels;

namespace RTF.Core.Models;

[Table("Admins")]
public record Admin : UserModel
{
    [Column("SuperRules")]
    public bool SuperRules { get; set; }
}