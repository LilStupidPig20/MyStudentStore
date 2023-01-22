using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.AdminResponseModels;
using RTF.CQS.Queries;

namespace RTF.WebApp.AdminControllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("admin/orders")]
public class OrdersAdminController : Controller
{
    private readonly IMediator _mediator;

    public OrdersAdminController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("getOrderStatusTypes")]
    public async Task<ActionResult<IReadOnlyList<OrderTypesFrame>>> GetOrderTypes()
    {
        var result = await _mediator.Send(new GetOrderTypesQuery());
        return Ok(result);
    }
    
    [HttpGet]
    [Route("getAllClosedOrders")]
    public async Task<ActionResult<IReadOnlyList<AdminOrderFrame>>> GetAllClosedOrders()
    {
        var result = await _mediator.Send(new GetAllClosedOrdersQuery());
        return Ok(result);
    }
    
    [HttpGet]
    [Route("getAllActiveOrders")]
    public async Task<ActionResult<IReadOnlyList<AdminOrderFrame>>> GetAllActiveOrders()
    {
        var result = await _mediator.Send(new GetActiveOrdersQuery());
        return Ok(result);
    }
    
    [HttpGet]
    [Route("getOrderFullInfo/{id}")]
    public async Task<ActionResult<AdminOrderExtendedInfo>> GetOrderFullInfo(Guid id)
    {
        var result = await _mediator.Send(new GetOrderFullInfoQuery
        {
            OrderId = id
        });
        return Ok(result);
    }

    [HttpPost]
    [Route("changeOrderStatus")]
    public async Task<IActionResult> ChangeOrderStatus(ChangeOrderStatusCommand command)
    {
        await _mediator.Send(command);
        return new OkResult();
    }
}