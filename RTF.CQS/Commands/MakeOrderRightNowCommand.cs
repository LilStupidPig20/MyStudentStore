using RTF.Core.Models.Enums;
using RTF.CQS.Abstractions;

namespace RTF.CQS.Commands;

public class MakeOrderRightNowCommand : Command
{
    public Guid StoreProductId { get; set; }
    
    public int Count { get; set; }
    
    public Size? Size { get; set; }
}