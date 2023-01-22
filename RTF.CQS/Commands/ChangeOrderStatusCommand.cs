using RTF.Core.Models.Enums;
using RTF.CQS.Abstractions;

namespace RTF.CQS.Commands;

public class ChangeOrderStatusCommand : Command
{
    public Guid OrderId { get; set; }
    
    public OrderStatus OrderStatus { get; set; }
}