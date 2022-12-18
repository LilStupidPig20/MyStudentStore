using System.ComponentModel.DataAnnotations.Schema;

namespace RTF.Core.Models;

[Table("StoreProduct")]
public record StoreProduct : DataModel
{
    [Column("Name")]
    public string Name { get; set; }
    
    [Column("Description")]
    public string Description { get; set; }
    
    [Column("Price")]
    public double Price { get; set; }
    
    [Column("TotalQuantity")]
    public int TotalQuantity { get; set; }
    
    [Column("Image")]
    public string Image { get; set; }
}