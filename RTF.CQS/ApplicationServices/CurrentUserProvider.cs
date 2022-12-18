using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RTF.Core.Models.IdentityModels;

namespace RTF.CQS.ApplicationServices;

public class CurrentUserProvider : ICurrentUserProvider
{
    private readonly UserManager<User> _userManager;
    
    public CurrentUserProvider(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<User> GetCurrentUserAsync()
    {
        var currentUserClaims = new HttpContextAccessor().HttpContext.User;
        var currentUser = (await _userManager.GetUserAsync(currentUserClaims));
        return currentUser;
    }
}