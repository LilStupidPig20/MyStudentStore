using System.ComponentModel.DataAnnotations.Schema;
using RTF.Core.Models.Enums;

namespace RTF.Core.Models;

[Table("ClothesInfo")]
public record ClothesInfo : DataModel
{
    [Column("Size")]
    public Size Size { get; set; }
    
    [Column("Count")]
    public int Count { get; set; }
}