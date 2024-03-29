﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTF.Core.Models;

public abstract record DataModel
{
    [Column("Id")]
    [Key]
    public Guid Id { get; set; }
}