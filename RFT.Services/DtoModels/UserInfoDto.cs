namespace RFT.Services.DtoModels;

public class UserInfoDto
{
    public new Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public string Group { get; set; }

    public string Email { get; set; }
}