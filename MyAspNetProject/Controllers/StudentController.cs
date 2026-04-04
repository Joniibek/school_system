using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Repositories;
using MyAspNetProject.Services;

namespace MyAspNetProject.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class StudentController(IStudentService service, ILogger logger) : ControllerBase
{
    
    [HttpGet("{id:int:min(0)}")]
    public ActionResult<Student>? GetById([FromRoute] int id)
    {
        Student? student = service.GetById(id);
        return Ok(student);
    }

    [HttpGet]
    public ActionResult<List<Student>> GetAll()
    {
        return Ok(service.GetAll());
    }

    [HttpPost]
    public ActionResult<StudentCreateResponseDto> Create([FromBody] StudentCreateDto studentDto)
    {
        logger.LogInformation($"Student creation was called with data {studentDto.ToString()}");
        StudentCreateResponseDto studentResponseDto = service.Create(studentDto);
        return Ok(studentResponseDto);
    }
}









