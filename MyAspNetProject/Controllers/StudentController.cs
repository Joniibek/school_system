using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.InfraStructure;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;
using MyAspNetProject.Repositories;

namespace MyAspNetProject.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class StudentController(
    IMediator mediator, ILogger<StudentController> logger
    ) : ControllerBase
{
    private IMediator _mediator = mediator;
    // private  IStudentRepository _repository = repository;
    
    [HttpPost]
    public async Task<ActionResult<StudentCreateResponseDto>> Create([FromBody] StudentCreateCommand studentCommand)
    {
        var student = await _mediator.Send(studentCommand);
        return Ok(student);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDetailedListDto>> GetById([FromRoute] Guid id)
    {
        var student = await _mediator.Send(new StudentDetailedQuery(id));
        return Ok(student);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<StudentListDto>>> List([FromQuery] StudentListQuery query)
    {
        var students = await _mediator.Send(query);
        return students;
    }
}









