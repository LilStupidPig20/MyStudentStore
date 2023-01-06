using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTF.Core.Models;

[Table("Basket")]
public record Basket : DataModel
{
    [Column("OrderProduct")]
    public ICollection<OrderProduct>? OrderProducts { get; set; }
    
    [Column("TotalPrice")]
    public double TotalPrice { get; set; }
    
    [Column("User")]
    [ForeignKey("UserInfo")]
    public virtual UserInfo User { get; set; }
}