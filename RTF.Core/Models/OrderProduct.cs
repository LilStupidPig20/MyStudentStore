using System.ComponentModel.DataAnnotations.Schema;
using RTF.Core.Models.Enums;

namespace RTF.Core.Models;

[Table("OrderProduct")]
public record OrderProduct : DataModel
{
    [Column("Product")]
    public StoreProduct Product { get; set; }

    [Column("Count")]
    public int Count { get; set; }

    [Column("Size")]
    public Size? Size { get; set; }
    
    /// <summary>
    /// Нужна отдельная от StoreProduct цена, т.к. в OrderProduct есть свойство Count, а данная стоимость
    /// Product * N нужна для отображения на UI
    /// </summary>
    [Column("Price")]
    public double Price { get; set; }
}