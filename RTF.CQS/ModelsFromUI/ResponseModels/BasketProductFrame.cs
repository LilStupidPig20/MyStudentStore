namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class BasketProductFrame
{
    /// <summary>
    /// Идентификатор части заказа, отвечающий за добавленные продукты одного типа
    /// </summary>
    public Guid BasketProductId { get; set; }
    
    /// <summary>
    /// Идентификатор самого продукта из магазина
    /// </summary>
    public Guid StoreProductId { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public double ProductPrice { get; set; }
    
    public int Count { get; set; }
    
    public string? ImageUrl { get; set; }
}