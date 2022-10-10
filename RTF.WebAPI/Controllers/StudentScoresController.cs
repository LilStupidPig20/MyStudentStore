using Microsoft.AspNetCore.Mvc;

namespace RtfStore.Controllers;

[ApiController]
public class StudentScoresController : Controller
{
    public StudentScoresController()
    {
        
    }
    
    [HttpGet]
    [Route("api/studentScore/get/{id:long}")]
    public Task<IActionResult> GetStudentScore(long id)
    {
        //return decimal score
        throw new NotImplementedException();
    }
}