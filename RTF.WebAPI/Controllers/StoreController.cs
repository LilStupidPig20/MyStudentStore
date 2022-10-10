using Microsoft.AspNetCore.Mvc;

namespace RtfStore.Controllers;

[ApiController]
public class StoreController
{
    public StoreController()
    {
        
    }

    [HttpGet]
    [Route("api/store/getAll")]
    public Task<IActionResult> GetAllProducts()
    {
        //return ProductCollection
        throw new NotImplementedException();
    }
    
    [HttpGet]
    [Route("api/store/getInfo/{id:long}")]
    public Task<IActionResult> GetProductInfo(long id)
    {
        //return Product
        throw new NotImplementedException();
    }
}