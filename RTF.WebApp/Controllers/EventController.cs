using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.WebApp.Controllers;

[ApiController]
[Route("api/events")]
[Authorize(Roles = "Student")]
public class EventController : Controller
{
    private readonly IMediator _mediator;

    public EventController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("getVisited")]
    public async Task<ActionResult<IReadOnlyList<EventFrame>>> GetVisitedEvents()
    {
        var result = await _mediator.Send(new GetVisitedEventsCommand());
        return Ok(result);
    }
    
    [HttpGet]
    [Route("getExtendedEventInfo/{id}")]
    public async Task<ActionResult<ExtendedEventInfoFrame>> GetExtendedEventInformation(long id)
    {
        var result = await _mediator.Send(new GetExtendedEventInformationCommand
        {
            EventId = id
        });
        return Ok(result);
    }
    
    [HttpGet]
    [Route("getCalendarInfo/{monthNum}")]
    public async Task<ActionResult<EventCalendarFrame>> GetCalendarInfo(int monthNum)
    {
        var result = await _mediator.Send(new GetCalendarInfoCommand
        {
            MonthNumber = monthNum
        });
        return Ok(result);
    }
    
    [HttpPost]
    [Route("getEventsByDateInterval")]
    public async Task<ActionResult<IReadOnlyList<EventFrame>>> GetEventsByDateInterval(
        GetEventsByDateIntervalCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}