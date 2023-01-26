using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.WebApp.Controllers;

[ApiController]
[Route("api/events")]
public class EventController : Controller
{
    private readonly IMediator _mediator;

    public EventController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("getVisited")]
    [Authorize(Roles = "Student")]
    public async Task<ActionResult<IReadOnlyList<EventFrame>>> GetVisitedEvents()
    {
        var result = await _mediator.Send(new GetVisitedEventsQuery());
        return Ok(result);
    }
    
    [HttpGet]
    [AllowAnonymous]
    [Route("getExtendedEventInfo/{id}")]
    public async Task<ActionResult<ExtendedEventInfoFrame>> GetExtendedEventInformation(Guid id)
    {
        var result = await _mediator.Send(new GetExtendedEventInformationQuery
        {
            EventId = id
        });
        return Ok(result);
    }
    
    [HttpGet]
    [AllowAnonymous]
    [Route("getCalendarInfo/{monthNum}")]
    public async Task<ActionResult<EventCalendarFrame>> GetCalendarInfo(int monthNum)
    {
        var result = await _mediator.Send(new GetCalendarInfoQuery
        {
            MonthNumber = monthNum
        });
        return Ok(result);
    }
    
    [HttpPost]
    [AllowAnonymous]
    [Route("getEventsByDateInterval")]
    public async Task<ActionResult<IReadOnlyList<EventFrame>>> GetEventsByDateInterval(
        GetEventsByDateIntervalQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}