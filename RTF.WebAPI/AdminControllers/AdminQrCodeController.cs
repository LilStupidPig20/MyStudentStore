using Microsoft.AspNetCore.Mvc;

namespace RtfStore.AdminControllers;

[ApiController]
public class  AdminQrCodeController : Controller
{
    public AdminQrCodeController()
    {
        
    }
    
    [HttpGet]
    [Route("api/adminVerifyCode/getTodayEvents")]
    public Task<IActionResult> GetTodayEvents()
    {
        //return [](Name, id, DateTime)
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [Route("api/adminVerifyCode/scan")]
    public Task<IActionResult> ScanQrCode()
    {
        //input {byte[] image, long eventId}
        //return OkResult();
        throw new NotImplementedException();
    }
}