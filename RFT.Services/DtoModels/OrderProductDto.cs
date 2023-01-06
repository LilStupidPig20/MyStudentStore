using RTF.Core.Models.Enums;

namespace RFT.Services.DtoModels;

public class OrderProductDto
{
    public Guid ProductId { get; set; }
    
    public int Count { get; set; }
    
    public Size? Size { get; set; }
}