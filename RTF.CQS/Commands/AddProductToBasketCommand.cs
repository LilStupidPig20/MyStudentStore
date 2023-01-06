using RTF.Core.Models.Enums;
using RTF.CQS.Abstractions;

namespace RTF.CQS.Commands;

public class AddProductToBasketCommand : Command
{
    public Guid ProductId { get; set; }
    
    public int Count { get; set; }
    
    public Size? Size { get; set; }
}