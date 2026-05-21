using Microsoft.AspNetCore.Mvc;

namespace WebApplication2;

[ApiController]
[Route("[controller]/[action]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        await Task.Delay(5000);
        return Ok("qweqwe");
    }
}
