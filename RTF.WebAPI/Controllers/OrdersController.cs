using Microsoft.AspNetCore.Mvc;

namespace RtfStore.Controllers;

[ApiController]
public class OrdersController
{
    public OrdersController()
    {
        
    }

    [HttpPost]
    [Route("api/orders/create")]
    public Task<IActionResult> CreateNew()
    {
        //input: Order.Products[](ModelFrame)
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [Route("api/orders/get/{id:long}")]
    public Task<IActionResult> Get(long id)
    {
        //return ProductInfo
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [Route("api/orders/getAll")]
    public Task<IActionResult> GetAll(long userId)
    {
        //return ProductInfoCollection
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [Route("api/orders/close/{id:long}")]
    public Task<IActionResult> Close(long id)
    {
        //return OkResult()
        throw new NotImplementedException();
    }
}