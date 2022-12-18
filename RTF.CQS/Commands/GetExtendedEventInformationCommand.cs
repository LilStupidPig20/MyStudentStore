using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.Commands;

public class GetExtendedEventInformationCommand : Command<ExtendedEventInfoFrame>
{
    public long? EventId { get; set; }
}