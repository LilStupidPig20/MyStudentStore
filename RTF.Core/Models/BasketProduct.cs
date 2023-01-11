using System.ComponentModel.DataAnnotations.Schema;
using RTF.Core.Models.Enums;

namespace RTF.Core.Models;

[Table("BasketProduct")]
public record BasketProduct : DataModel
{
    [Column("Product")]
    public virtual StoreProduct Product { get; set; }

    [Column("Count")]
    public int Count { get; set; }

    [Column("Size")]
    public Size? Size { get; set; }
}