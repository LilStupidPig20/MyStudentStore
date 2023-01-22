using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.Queries;

public class GetEventVisitorsQuery : Query<IReadOnlyList<VisitorFrame>>
{
    public Guid EventId { get; set; }
}