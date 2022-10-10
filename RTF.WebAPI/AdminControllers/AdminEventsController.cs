using Microsoft.AspNetCore.Mvc;

namespace RtfStore.AdminControllers;

[ApiController]
public class AdminEventsController
{
    public AdminEventsController()
    {
        
    }

    [HttpPost]
    [Route("api/adminEvents/create")]
    public Task<IActionResult> CreateNewEvent()
    {
        //return OkResult()
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [Route("api/adminEvents/changeEvent/{id:long}")]
    public Task<IActionResult> ChangeEventInfo(long id)
    {
        // input: EventInfo (ModelFrame)
        // return OkResult()
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [Route("api/adminEvents/close/{id:long}")]
    public Task<IActionResult> CloseEvent(long id)
    {
        //return OkResult
        throw new NotImplementedException();
    }
    
    [HttpDelete]
    [Route("api/adminEvents/delete/{id:long}")]
    public Task<IActionResult> DeleteEvent(long id)
    {
        //return OkResult
        throw new NotImplementedException();
    }
    
    [HttpGet]
    [Route("api/adminEvents/getAllVerifiedParticipants/{id:long}")]
    public Task<IActionResult> GetAllVerifiedParticipants(long eventId)
    {
        //return SmallInfoUserCollection (not fullInfo)
        throw new NotImplementedException();
    }
}