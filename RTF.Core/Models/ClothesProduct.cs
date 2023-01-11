using System.ComponentModel.DataAnnotations.Schema;
using RTF.Core.Models.IdentityModels;

namespace RTF.Core.Models;

[Table("ClothesProduct")]
public record ClothesProduct : StoreProduct
{
    [Column("ClothesInfo")]
    public virtual ICollection<ClothesInfo> ClothesInfos { get; set; } = new List<ClothesInfo>();
}