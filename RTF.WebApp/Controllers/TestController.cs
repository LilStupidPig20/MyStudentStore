using Microsoft.AspNetCore.Mvc;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RTF.WebApp.Controllers;

[ApiController]
[Route("test")]
public class TestController : Controller
{
    private readonly UserRepository _userRepository;

    public TestController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet]
    [Route("getAllUsers")]
    public async Task<IList<User>> GetAllUsers()
    {
        return await _userRepository.GetAllAsync();
    }
}