using RTF.CQS.Abstractions;

namespace RTF.CQS.Commands;

public class IncrementProductInBasketCommand : Command
{
    public Guid ProductId { get; set; }
}