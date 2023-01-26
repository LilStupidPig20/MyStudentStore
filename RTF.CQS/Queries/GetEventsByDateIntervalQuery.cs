using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.Queries;

public class GetEventsByDateIntervalQuery : Query<IReadOnlyList<EventFrame>>
{
    public DateTime StartDateTime { get; set; }
    
    public DateTime EndDateTime { get; set; }
}