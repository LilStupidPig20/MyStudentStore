using System.ComponentModel.DataAnnotations;

namespace RTF.Core.Models;

public interface IDataModel
{
    public Guid Id { get; set; }
}