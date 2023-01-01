using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.Commands;

public class GetEventsByDateIntervalCommand : Command<IReadOnlyList<EventFrame>>
{
    public DateTime StartDateTime { get; set; }
    
    public DateTime EndDateTime { get; set; }
}