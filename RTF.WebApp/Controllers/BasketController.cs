using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.WebApp.Controllers;

[ApiController]
[Route("api/basket")]
[Authorize(Roles = "Student")]
public class BasketController : Controller
{
    private readonly IMediator _mediator;

    public BasketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get")]
    public async Task<ActionResult<BasketFrame>> GetUserBasket()
    {
        var result = await _mediator.Send(new GetUserBasketQuery());
        return result;
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> AddProductToBasket(AddProductToBasketCommand command)
    {
        await _mediator.Send(command);
        return new OkResult();
    }

    [HttpPost]
    [Route("remove")]
    public async Task<IActionResult> RemoveProductFromBasket(RemoveProductFromBasketCommand command)
    {
        await _mediator.Send(command);
        return new OkResult();
    }
    
    [HttpPost]
    [Route("incrementProductCount")]
    public async Task<IActionResult> IncrementProductInBasket(IncrementProductInBasketCommand command)
    {
        await _mediator.Send(command);
        return new OkResult();
    }

    [HttpPost]
    [Route("decrementProductCount")]
    public async Task<IActionResult> DecrementProductInBasket(DecrementProductInBasketCommand command)
    {
        await _mediator.Send(command);
        return new OkResult();
    }
}