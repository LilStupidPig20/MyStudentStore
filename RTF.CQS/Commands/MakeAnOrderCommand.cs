using RTF.CQS.Abstractions;

namespace RTF.CQS.Commands;

public class MakeAnOrderCommand : Command
{
    public IReadOnlyList<Guid> BasketProductsIds { get; set; }
}