namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class ProductFrame
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public double Price { get; set; }
    
    public bool NotAvailable { get; set; }
    
    public string Image { get; set; }
}