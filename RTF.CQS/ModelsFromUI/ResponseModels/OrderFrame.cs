using RTF.Core.Models.Enums;

namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class OrderFrame
{
    public Guid OrderId { get; set; }

    public OrderStatus Status { get; set; }
    
    public IReadOnlyList<OrderProductFrame> OrderProducts { get; set; }
}