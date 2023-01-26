using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFT.Services.Helpers;

namespace RTF.WebApp.Controllers;

[ApiController]
public class TestController : Controller
{
    private readonly IDataInitializer _dataInitializer;

    public TestController(IDataInitializer dataInitializer)
    {
        _dataInitializer = dataInitializer;
    }
    
    [HttpGet]
    [AllowAnonymous]
    [Route("api/test/initData")]
    public async Task<IActionResult> InitData()
    {
        await _dataInitializer.InitDataAsync();
        return new OkResult();
    }
}