namespace RTF.CQS.ModelsFromUI.AdminResponseModels;

public class AdminOrderProductFrame
{
    public Guid ProductId { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public int Count { get; set; }
    
    /// <summary>
    /// Price = Цена продукта из магазина * его кол-во в заказе
    /// </summary>
    public double Price { get; set; }
}