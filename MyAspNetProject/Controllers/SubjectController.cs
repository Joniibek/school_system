using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Exceptions;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;

namespace MyAspNetProject.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SubjectController(IMediator mediator): ControllerBase
{
    private readonly IMediator _mediator = mediator;
    [HttpPost]
    public async Task<ActionResult<ActionResult<string>>> Create([FromBody] SubjectCreateCommand data)
    {
        var createdSubject = await _mediator.Send(data);
        return Ok(createdSubject);
    }

    [HttpGet]
    public async Task<ActionResult<List<SubjectListDto>>> List([FromQuery] SubjectListQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}