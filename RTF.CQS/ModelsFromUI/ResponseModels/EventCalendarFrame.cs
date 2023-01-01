using RTF.Core.Models.Enums;

namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class EventCalendarFrame
{
    public string Month { get; set; }
    
    public Dictionary<int, List<EventType>> DayToEventsList { get; set; } 
}