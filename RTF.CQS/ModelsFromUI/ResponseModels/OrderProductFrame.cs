using RTF.Core.Models.Enums;

namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class OrderProductFrame
{
    public Guid ProductId { get; set; }
    
    public string Name { get; set; }
    
    public int Count { get; set; }
    
    public double Price { get; set; }
    
    public Size? Size { get; set; }
}