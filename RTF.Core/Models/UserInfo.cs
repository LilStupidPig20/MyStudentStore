﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTF.Core.Models;

[Table("UserInfo")]
public record UserInfo : DataModel
{
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
    
    [Column("UserBalance")]
    public double Balance { get; set; }

    [Column("Basket")]
    public virtual Basket Basket { get; set; }
    
    [Column("QrCodeGuid")]
    public virtual Guid QrCodeId { get; set; }
    
    [Column("VisitedEvents")]
    public virtual ICollection<Event> VisitedEvents { get; set; }
}