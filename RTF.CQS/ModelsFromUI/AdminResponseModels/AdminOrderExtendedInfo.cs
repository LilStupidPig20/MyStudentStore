using RTF.Core.Models.Enums;

namespace RTF.CQS.ModelsFromUI.AdminResponseModels;

public class AdminOrderExtendedInfo
{
    public Guid OrderId { get; set; }
    
    public string StudentFullName { get; set; }
    
    public OrderStatus Status { get; set; }
    
    public DateTime PurchaseDate { get; set; }
    
    public IReadOnlyList<AdminOrderProductFrame> OrderProducts { get; set; }
}