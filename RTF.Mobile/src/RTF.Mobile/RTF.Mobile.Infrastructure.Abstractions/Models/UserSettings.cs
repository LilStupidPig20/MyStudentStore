namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class UserSettings
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Group { get; }

        public string Email { get; }

        public string Token { get; }

        public UserSettings()
        {
        }

        public UserSettings(string firtsName, string lastName, string group, string email, string token)
        {
            FirstName = firtsName;
            LastName = lastName;
            Group = group;
            Email = email;
            Token = token;
        }
    }
}
