using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects.DataClasses;

namespace RTF.Core.Models.Enums;

[EdmEnumType]
public enum EventType
{
    Entertainment = 0,
    Academic = 1
}