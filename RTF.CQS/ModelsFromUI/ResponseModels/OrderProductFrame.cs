namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class OrderProductFrame
{
    public Guid ProductId { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public double ProductPrice { get; set; }
    
    public int Count { get; set; }
    
    public string? ImageUrl { get; set; }
}