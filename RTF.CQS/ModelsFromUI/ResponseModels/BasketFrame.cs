namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class BasketFrame
{
    public double? TotalPrice { get; set; }
    
    public List<BasketProductFrame> BasketProducts { get; set; }
}