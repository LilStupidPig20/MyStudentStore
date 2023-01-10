using System.ComponentModel.DataAnnotations.Schema;

namespace RTF.Core.Models;

[Table("Basket")]
public record Basket : DataModel
{
    [Column("BasketProduct")]
    public virtual ICollection<BasketProduct> BasketProducts { get; set; } = new List<BasketProduct>();

    public virtual UserInfo UserInfo { get; set; }
    
    public Guid UserInfoId { get; set; }
}   