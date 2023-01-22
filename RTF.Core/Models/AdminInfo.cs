using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTF.Core.Models;

[Table("AdminInfo")]
public record AdminInfo : DataModel
{
    [Column("Id")]
    [Required]
    [Key]
    public new Guid Id { get; set; }

    [Column("FirstName")]
    [Required]
    public string FirstName { get; set; }
    
    [Column("LastName")]
    [Required]
    public string LastName { get; set; }

    [Column("Group")]
    public string Group { get; set; }
    
    [Column("Email")]
    public string Email { get; set; }
    
    [Column("EventsParticipated")]
    public ICollection<Event> EventsParticipated { get; set; }
}