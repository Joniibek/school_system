using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.InfraStructure;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;
using MyAspNetProject.Repositories;
using MyAspNetProject.Services;

namespace MyAspNetProject.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class StudentController( IStudentService service, ILogger<StudentController> logger) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<StudentCreateResponseDto>> Create([FromBody] StudentCreateDto studentDto)
    {
        StudentCreateResponseDto? studentResponseDto = await service.Create(studentDto);
        if (studentResponseDto is null) return NotFound("Something went wrong");
        
        return Ok(studentResponseDto);
    }
    
    [HttpGet("{id:int:min(0)}")]
    public async Task<ActionResult<StudentDetailedListDto>> GetById([FromRoute] int id)
    {
        StudentDetailedListDto? student = await service.GetById(id);
        if (student is null)
            return NotFound($"Student with id - {id} was not found");
        
        return Ok(student);
    }

    [HttpGet]
    public async Task<ActionResult<List<StudentListDto>>> List([FromQuery] StudentListQuery query)
    {
        return Ok(await service.List(query));
    }
}









