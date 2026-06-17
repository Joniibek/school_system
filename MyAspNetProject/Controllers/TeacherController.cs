using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;

namespace MyAspNetProject.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TeacherController(IMediator mediator): ControllerBase
{
    private readonly IMediator _mediator = mediator;
    
    [HttpPost]
    public async Task<ActionResult<TeacherShortListDto>> Create([FromBody] TeacherCreateCommand data)
    {
        var teacher = await _mediator.Send(data);
        return Created("Объект успешно создан", teacher);
    }

    [HttpPost]
    public async Task<ActionResult> SetSubjects([FromBody] TeacherSubjectsSetCommand data)
    {
        await _mediator.Send(data);
        return Ok("Операция прошла успешно");
    }

    [HttpGet]
    public async Task<ActionResult<List<TeacherListDto>>> List([FromQuery] TeacherListQuery query)
    {
        List<TeacherListDto> teacherListDtos = await _mediator.Send(query);
        return Ok(teacherListDtos);
    }
}