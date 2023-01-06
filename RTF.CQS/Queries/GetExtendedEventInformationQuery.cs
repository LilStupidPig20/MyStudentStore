using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.Queries;

public class GetExtendedEventInformationQuery : Query<ExtendedEventInfoFrame>
{
    public Guid? EventId { get; set; }
}