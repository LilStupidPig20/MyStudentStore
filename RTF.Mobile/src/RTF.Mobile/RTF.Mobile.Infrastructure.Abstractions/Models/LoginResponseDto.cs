namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class LoginResponseDto
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Group { get; }

        public string UserName { get; }

        public string Token { get; }

        public LoginResponseDto()
        {
        }

        public LoginResponseDto(string firstName, string lastName, string group, string userName, string token)
        {
            FirstName = firstName;
            LastName = lastName;
            Group = group;
            UserName = userName;
            Token = token;
        }
    }
}
