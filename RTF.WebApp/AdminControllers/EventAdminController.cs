using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.WebApp.AdminControllers;

[ApiController]
[Route("api/adminEvent")]
[Authorize(Roles = "Admin")]
public class EventAdminController : Controller
{
    private readonly IMediator _mediator;

    public EventAdminController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Route("createEvent")]
    public async Task<IActionResult> CreateEvent(CreateEventQuery query)
    {
        await _mediator.Send(query);
        return new OkResult();
    }

    [HttpGet]
    [Route("getOrganizers")]
    public async Task<ActionResult<IReadOnlyList<OrganizerFrame>>> GetAllOrganizers()
    {
        var result = await _mediator.Send(new GetAllOrganizersCommand());
        return Ok(result);
    }
}