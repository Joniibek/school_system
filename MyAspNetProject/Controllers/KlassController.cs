using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;
using MyAspNetProject.Services;

namespace MyAspNetProject.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class KlassController(IKlassService service, ILogger<KlassController> logger): ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<KlassListDto>> Create([FromBody] KlassCreateDto klassCreateDto)
    {
        KlassCreateResponseDto? klassDto = await service.Create(klassCreateDto);
        if (klassDto is null)
            return ValidationProblem("Unique constraint");
        await service.Create(klassCreateDto);
        return Created();
    }

    [HttpGet]
    public async Task<ActionResult<List<KlassListDto>>> List([FromQuery] KlassListQuery query) 
    {
        return await service.List(query);
    }

    [HttpDelete("{id:int:min(0)}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await service.Delete(id);
        return NoContent();
    }

    // [HttpPut("{id:int:min(0)}")]
    // public async Task<ActionResult> UpdateStudent(
    //     [FromRoute] int id,
    //     [FromBody] BaseUserUpdateDto updateDto)
    
}








