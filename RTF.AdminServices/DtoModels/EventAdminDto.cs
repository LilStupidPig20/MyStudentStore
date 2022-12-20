using RTF.Core.Models;

namespace RTF.AdminServices.DtoModels;

public class EventAdminDto
{
    public string Name { get; set; }
    
    public DateTime StartDateTime { get; set; }
    
    public string Description { get; set; }
    
    public List<AdminInfoDto> Organizers { get; set; }
    
    public double Coins { get; set; }
}