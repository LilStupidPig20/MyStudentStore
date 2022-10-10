using Microsoft.AspNetCore.Mvc;

namespace RtfStore.Controllers;

[ApiController]
public class QrCodeController : Controller
{
    public QrCodeController()
    {
        
    }
    
    [HttpGet]
    [Route("api/verifyCode/get/{id:long}")]
    public Task<IActionResult> GetQrCode(long id)
    {
        // return QrImage as byte[]
        throw new NotImplementedException();
    }
}