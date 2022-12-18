using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.WebApp.Controllers;

[ApiController]
[Route("api/store")]
[Authorize(Roles = "Student")]
public class StoreController : Controller
{
    private readonly IMediator _mediator;

    public StoreController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("getAllProducts")]
    public async Task<ActionResult<IReadOnlyList<ProductFrame>>> GetAllProducts()
    {
        var result = await _mediator.Send(new GetAllProductsCommand());
        return Ok(result);
    }
}