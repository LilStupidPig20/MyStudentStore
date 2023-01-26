using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTF.CQS.Commands;
using RTF.CQS.Queries;

namespace RTF.WebApp.Controllers;

[ApiController]
[Route("api/userBalance")]
public class UserBalanceController : Controller
{
    private readonly IMediator _mediator;

    public UserBalanceController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("getCurrentUserBalance")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> GetCurrentUserBalance()
    {
        var result = await _mediator.Send(new GetCurrentUserBalanceQuery());

        return Ok(result);
    }
}