namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class LoginDto
    {
        public string Email { get; }

        public string Password { get; }

        public bool RememberMe { get; }

        public LoginDto(string email, string password, bool rememberMe)
        {
            Email = email;
            Password = password;
            RememberMe = rememberMe;
        }
    }
}
