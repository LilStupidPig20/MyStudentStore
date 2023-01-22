using RTF.Core.Models.Enums;

namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class ExtendedProductInfoFrame
{
    public Guid ProductId { get; set; }
    
    public string Name { get; set; }
    
    public double Price { get; set; }
    
    public string? Description { get; set; }
    
    public string? Image { get; set; }
    
    // Отношение размера товара к тому имеется ли он. True - есть в наличии. Если словарь - null - значит товар - не одежда
    public Dictionary<Size, bool>? SizesToAvailable { get; set; }
}