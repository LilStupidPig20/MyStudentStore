namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class LoginResponseDto
    {
        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public string Group { get; internal set; }

        public string UserName { get; internal set; }

        public string Token { get; internal set; }

        public string Role { get; internal set; }

        public LoginResponseDto()
        {
        }

        public LoginResponseDto(string firstName, string lastName, string group, string userName, string token, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Group = group;
            UserName = userName;
            Token = token;
            Role = role;
        }
    }
}
