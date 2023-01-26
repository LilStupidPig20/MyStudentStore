using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.WebApp.Controllers;

[ApiController]
[Route("api/store")]
public class StoreController : Controller
{
    private readonly IMediator _mediator;

    public StoreController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("getAllProducts")]
    [AllowAnonymous]
    public async Task<ActionResult<IReadOnlyList<ProductFrame>>> GetAllProducts()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return Ok(result);
    }
    
    [HttpGet]
    [Route("getProductFullInfo/{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<ExtendedProductInfoFrame>> GetProductFullInfo(Guid id)
    {
        var result = await _mediator.Send(new GetProductFullInfoQuery
        {
            ProductId = id
        });
        return Ok(result);
    }

    
    [HttpGet]
    [Route("getOrders")]
    [Authorize(Roles = "Student")]
    public async Task<ActionResult<IReadOnlyList<OrderFrame>>> GetOrders()
    {
        var result = await _mediator.Send(new GetStudentOrdersQuery());
        return Ok(result);
    }

    [HttpPost]
    [Route("makeAnOrder")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> MakeAnOrder(MakeAnOrderCommand command)
    {
        await _mediator.Send(command);
        return new OkResult();
    }

    [HttpPost]
    [Route("makeOrderRightNow")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> MakeOrderRightNow(MakeOrderRightNowCommand command)
    {
        await _mediator.Send(command);
        return new OkResult();
    }

    [HttpPost]
    [Route("CancelOrder")]
    [Authorize(Roles = "Student")]
    public async Task<ActionResult<IReadOnlyList<ProductFrame>>> CancelOrder(CancelOrderCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}