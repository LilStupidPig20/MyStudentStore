namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class RegisterDto
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Group { get; }

        public string Email { get; }

        public string Password { get; }

        public string ConfirmPassword { get; }

        public RegisterDto(string firstName, string lastName, string group, string email, string password, string confirmPassword)
        {
            FirstName = firstName;
            LastName = lastName;
            Group = group;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
