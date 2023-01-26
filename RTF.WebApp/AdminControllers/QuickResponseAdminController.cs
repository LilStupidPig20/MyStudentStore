using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTF.CQS.Commands;

namespace RTF.WebApp.AdminControllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/adminQr")]
public class QuickResponseAdminController : Controller
{
    private readonly IMediator _mediator;

    public QuickResponseAdminController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Route("scanCode")]
    public async Task<IActionResult> ScanQrCode(ScanQrCodeCommand command)
    {
        await _mediator.Send(command);
        return new OkResult();
    }
}