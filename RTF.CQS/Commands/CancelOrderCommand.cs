using RTF.CQS.Abstractions;

namespace RTF.CQS.Commands;

public class CancelOrderCommand : Command
{
    public Guid OrderId { get; set; }
    
    public string? CancellationComment { get; set; }
}