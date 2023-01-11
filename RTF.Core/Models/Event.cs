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
    public virtual ICollection<UserInfo> Users { get; set; } = new List<UserInfo>();
    
    [Column("Organizers")]
    public virtual ICollection<AdminInfo> Organizers { get; set; } = new List<AdminInfo>();
    
    [Column("EventType")]
    [EnumDataType(typeof(EventType))]
    public EventType EventType { get; set; }
    
    [Column("Coins")]
    public double Coins { get; set; }
}