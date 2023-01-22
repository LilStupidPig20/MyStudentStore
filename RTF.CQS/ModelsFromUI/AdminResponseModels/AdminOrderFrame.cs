using RTF.Core.Models.Enums;

namespace RTF.CQS.ModelsFromUI.AdminResponseModels;

public class AdminOrderFrame
{
    public Guid OrderId { get; set; }
    
    public string StudentFullName { get; set; }

    /// <summary>
    /// Товары в заказе в виде строки с разделителем ", "
    /// </summary>
    public string OrderProducts { get; set; }
    
    public OrderStatus Status { get; set; }
}