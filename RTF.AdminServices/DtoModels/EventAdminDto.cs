using RTF.Core.Models;
using RTF.Core.Models.Enums;

namespace RTF.AdminServices.DtoModels;

public class EventAdminDto
{
    public string Name { get; set; }
    
    public DateTime StartDateTime { get; set; }
    
    public DateTime EndDateTime { get; set; }
    
    public string Description { get; set; }
    
    public List<Guid> Organizers { get; set; }
    
    public double Coins { get; set; }
    
    public EventType EventType { get; set; }
}