using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace RtfStore.Controllers;

[ApiController]
public class AccountController : Controller
{
    public AccountController()
    {
        
    }

    [HttpPost]
    [Route("api/account/authorize")]
    public Task<IActionResult> Authorize(string login, string password)
    {
        //return token, id
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [Route("api/account/register")]
    public Task<IActionResult> Register(string surname, string name, string group, string email,
        string password, string confirmPassword)
    {
        // return OkResult(); + email message
        throw new NotImplementedException();
    }
}