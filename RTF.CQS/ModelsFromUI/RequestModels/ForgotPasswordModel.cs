using System.ComponentModel.DataAnnotations;

namespace RTF.CQS.ModelsFromUI.RequestModels;

public class ForgotPasswordModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}