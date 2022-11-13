using RTF.Core.Models.IdentityModels;

namespace RTF.Infrastructure.Helpers;

public interface ITokenGenerator
{ 
    string GenerateToken(User user, IList<string> roles);
}