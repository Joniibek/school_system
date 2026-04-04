using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Services;

namespace MyAspNetProject.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class KlassController(IKlassService service, ILogger logger): ControllerBase
{
    [HttpPost]
    public ActionResult<KlassCreateResponseDto> Create([FromBody] KlassCreateDto klassCreateDto)
    {
        logger.LogInformation($"Klass creation was called with data {klassCreateDto.ToString()}");
        return Ok(service.Create(klassCreateDto));
    }
}