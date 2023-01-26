namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class ProductFrame
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public double Price { get; set; }
    
    public bool NotAvailable { get; set; }
    
    public string Image { get; set; }
    
    // По факту служебная инфа, нужная админу, но за день до защиты влепил сюда
    public int StorageQuantity { get; set; }
}