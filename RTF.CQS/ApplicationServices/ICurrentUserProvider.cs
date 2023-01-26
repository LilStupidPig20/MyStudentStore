using RTF.Core.Models.IdentityModels;

namespace RTF.CQS.ApplicationServices;

public interface ICurrentUserProvider
{
    Task<User> GetCurrentUserAsync();
}