using Microsoft.AspNetCore.Mvc;

namespace RtfStore.Controllers;

[ApiController]
public class EventsController
{
    public EventsController()
    {
        
    }

    [HttpGet]
    [Route("api/events/getAll")]
    public Task<IActionResult> GetAll()
    {
        // return EventCollection
        throw new NotImplementedException();
    }
    
    [Route("api/events/getEventInfo/{id:long}")]
    public Task<IActionResult> GetEventInfo(long id)
    {
        //return EventInfo
        throw new NotImplementedException();
    }
}