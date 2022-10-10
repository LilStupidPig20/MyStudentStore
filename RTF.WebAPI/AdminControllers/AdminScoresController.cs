using Microsoft.AspNetCore.Mvc;

namespace RtfStore.AdminControllers;

[ApiController]
public class AdminScoresController : Controller
{
    public AdminScoresController()
    {
        
    }
    
    [HttpGet]
    [Route("api/adminScore/addScores")]
    public Task<IActionResult> AddScores()
    {
        //input: {decimal score, [{long userId}]}
        //return OkResult();
        throw new NotImplementedException();
    }
}