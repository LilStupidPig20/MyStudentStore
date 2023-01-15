using RTF.Core.Models.Enums;

namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class EventFrame
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime StartDateTime { get; set; }
    
    public DateTime EndDateTime { get; set; }
    
    public EventType EventType { get; set; }
}