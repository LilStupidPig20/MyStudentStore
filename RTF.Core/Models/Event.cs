using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RTF.Core.Models.Enums;
using RTF.Core.Models.IdentityModels;

namespace RTF.Core.Models;

[Table("Event")]
public record Event : DataModel
{
    [Column("Name")]
    public string Name { get; set; }
    
    [Column("Description")]
    public string? Description { get; set; }    
    
    [Column("StartDateTime")]
    public DateTime StartDateTime { get; set; }
    
    [Column("DurationInMinutes")]
    public int DurationInMinutes { get; set; }
    
    [Column("IsFinished")]
    public bool IsFinished { get; set; }
    
    [Column("Users")]
    public ICollection<UserInfo> Users { get; set; }
    
    [Column("Organizers")]
    public ICollection<AdminInfo> Organizers { get; set; }
    
    [Column("EventType")]
    [EnumDataType(typeof(EventType))]
    public EventType EventType { get; set; }
    
    [Column("Coins")]
    public double Coins { get; set; }
}