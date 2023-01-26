using System.ComponentModel.DataAnnotations.Schema;
using RTF.Core.Models.Enums;

namespace RTF.Core.Models;

[Table("Order")]
public record Order : DataModel
{
    [Column("Student")]
    public virtual UserInfo Student { get; set; }
    
    [Column("OrderProduct")]
    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    
    [Column("TotalPrice")]
    public double TotalPrice { get; set; } 
    
    [Column("PurchaseTime")]
    public DateTime PurchaseTime { get; set; }
    
    [Column("Status")]
    public OrderStatus Status { get; set; }
    
    [Column("CancellationComment")]
    public string? CancellationComment { get; set; }
}