using RTF.Core.Models.Enums;

namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class ExtendedEventInfoFrame
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTime StartDateTime { get; set; }
    
    public int DurationInMinutes { get; set; }

    public EventType EventType { get; set; }
    
    private double Coins { get; set; }
}