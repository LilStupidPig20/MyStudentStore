using RTF.Core.Models.Enums;
using RTF.CQS.Abstractions;

namespace RTF.CQS.Commands;

public class RemoveProductFromBasketCommand : Command
{
    public Guid ProductId { get; set; }

    public Size? Size { get; set; }
}