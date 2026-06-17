using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;

namespace MyAspNetProject.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class KlassController(ILogger<KlassController> logger, IMediator mediator): ControllerBase
{
    private IMediator _mediator = mediator;
    [HttpPost]
    public async Task<ActionResult<KlassListDto>> Create([FromBody] KlassCreateCommand klassCreateCommand)
    {
        KlassCreateResponseDto? klassDto = await _mediator.Send(klassCreateCommand);
        return Created();
    }

    [HttpGet]
    public async Task<ActionResult<List<KlassListDto>>> List([FromQuery] KlassListQuery query) 
    {
        var klassListDtos = await _mediator.Send(query);
        return Ok(klassListDtos);
    }
    
    // [HttpDelete("{id}")]
    // public async Task<ActionResult> Delete([FromRoute] Guid id)
    // {
    //     await service.Delete(id);
    //     return NoContent();
    // }
    //
    // [HttpPut("{id:int:min(0)}")]
    // public async Task<ActionResult> UpdateStudent(
    //     [FromRoute] int id,
    //     [FromBody] BaseUserUpdateDto updateDto)
    //
}








