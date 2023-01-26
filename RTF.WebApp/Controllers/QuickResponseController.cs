using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTF.CQS.Queries;

namespace RTF.WebApp.Controllers;

[ApiController]
[Route("api/qrCode")]
public class QuickResponseController : Controller
{
    private readonly IMediator _mediator;

    public QuickResponseController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("getActualQrCodeId")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> GetActualQrCodeId()
    {
        var result = await _mediator.Send(new GetStudentQrId());

        return Ok(result);
    }
}