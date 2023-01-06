using System.ComponentModel.DataAnnotations.Schema;
using RTF.Core.Models.Enums;

namespace RTF.Core.Models;

[Table("Order")]
public record Order : DataModel
{
    [Column("Student")]
    public UserInfo Student { get; set; }
    
    [Column("OrderProduct")]
    public List<OrderProduct> OrderProducts { get; set; }
    
    [Column("TotalPrice")]
    public double TotalPrice { get; set; } 
    
    [Column("PurchaseTime")]
    public DateTime PurchaseTime { get; set; }
    
    [Column("Status")]
    public OrderStatus Status { get; set; }
    
    [Column("CancellationComment")]
    public string? CancellationComment { get; set; }
}