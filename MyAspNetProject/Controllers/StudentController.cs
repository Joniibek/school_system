using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Repositories;
using MyAspNetProject.Services;

namespace MyAspNetProject.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class StudentController(IStudentService service, ILogger<StudentController> logger) : ControllerBase
{
    
    [HttpGet("{id:int:min(0)}")]
    public ActionResult<Student>? GetById([FromRoute] int id)
    {
        Student? student = service.GetById(id);
        if (student is null)
            return NotFound($"Student with id - {id} was not found");
        
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

    [HttpDelete("{id:int:min(0)}")]
    public ActionResult<string> Delete([FromRoute] int id)
    {
        service.Delete(id);
        return Ok();
    }

    [HttpGet("{year:int:min(0):max(11)}")]
    public ActionResult<List<StudentCreateResponseDto>> GetAllByYearGroup
    ([FromRoute] int year, [FromQuery] string? group)
    {
        var studentListDtos = service.GetAllByYear(year, group);
        return Ok(studentListDtos);
    }
}









