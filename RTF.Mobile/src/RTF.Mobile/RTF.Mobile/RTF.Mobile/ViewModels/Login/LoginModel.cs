using RTF.Mobile.Utils.Models;

namespace RTF.Mobile.ViewModels.Login
{
    public class LoginModel : EditableModel
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
