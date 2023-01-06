using RTF.CQS.Abstractions;

namespace RTF.CQS.Commands;

public class DecrementProductInBasketCommand : Command
{
    public Guid ProductId { get; set; }
}