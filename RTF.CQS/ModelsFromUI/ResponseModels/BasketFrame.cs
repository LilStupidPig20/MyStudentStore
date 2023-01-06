namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class BasketFrame
{
    public double TotalPrice { get; set; }
    
    public List<OrderProductFrame> Products { get; set; }
}