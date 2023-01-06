using System.ComponentModel.DataAnnotations.Schema;
using RTF.Core.Models.IdentityModels;

namespace RTF.Core.Models;

[Table("ClothesProduct")]
public record ClothesProduct : StoreProduct
{
    [Column("ClothesInfo")]
    public ICollection<ClothesInfo> ClothesInfos { get; set; }
}