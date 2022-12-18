using RTF.Core.Models.Enums;

namespace RTF.Core.Models.IdentityModels;

public record ClothesInfo : DataModel
{
    public Size Size { get; set; }
    
    public int Count { get; set; }
}