namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class UserSettings
    {
        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public string Group { get; internal set; }

        public string Email { get; internal set; }

        public string Token { get; internal set; }

        public string Role { get; internal set; }

        public UserSettings()
        {
        }

        public UserSettings(string firstName, string lastName, string group, string email, string token, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Group = group;
            Email = email;
            Token = token;
            Role = role;
        }
    }
}
