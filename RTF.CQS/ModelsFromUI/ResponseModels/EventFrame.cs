using RTF.Core.Models.Enums;

namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class EventFrame
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime StartDateTime { get; set; }
    
    public int DurationInMinutes { get; set; }
    
    public EventType EventType { get; set; }
}