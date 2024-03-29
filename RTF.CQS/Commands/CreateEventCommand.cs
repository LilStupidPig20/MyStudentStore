using RTF.Core.Models.Enums;
using RTF.CQS.Abstractions;

namespace RTF.CQS.Commands;

public class CreateEventCommand : Command<bool> 
{
    public string Name { get; set; }
    
    public DateTime StartDateTime { get; set; }
    
    public DateTime EndDateTime { get; set; }
    
    public string Description { get; set; }
    
    public List<Guid> Organizers { get; set; }
    
    public double Coins { get; set; }
    
    /// <summary>
    /// Entertainment = 0,
    /// Academic = 1
    /// </summary>
    public EventType EventType { get; set; }
}