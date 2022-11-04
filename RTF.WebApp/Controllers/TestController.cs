using MediatR;
using Microsoft.AspNetCore.Mvc;
using RTF.CQS.Commands;

namespace RTF.WebApp.Controllers;

[ApiController]
[Route("test")]
public class TestController : Controller
{
    private readonly IMediator _mediator;

    public TestController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("getAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _mediator.Send(new GetAllStudentsQuery());
        return Ok(result);
    }
}