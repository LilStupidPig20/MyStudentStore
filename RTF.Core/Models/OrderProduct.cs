using System.ComponentModel.DataAnnotations.Schema;
using RTF.Core.Models.Enums;

namespace RTF.Core.Models;

[Table("OrderProduct")]
public record OrderProduct : DataModel
{
    [Column("Product")]
    public virtual StoreProduct Product { get; set; }
    
    [Column("Size")]
    public Size? Size { get; set; }
    
    [Column("Count")]
    public int Count { get; set; }
    
    /// <summary>
    /// Подумал, что лучше в случае с заказами хранить в базе прайс на элемент заказа (цена продукта * его количество)
    /// потому что в случае с заказом этот объект неизменяемый, а в корзине он бы постоянно менялся, соотв-но там этого поля нет
    /// </summary>
    [Column("Price")]
    public double Price { get; set; }
}