using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Exceptions;
using MyAspNetProject.Models.Domain;

namespace MyAspNetProject.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SubjectController: ControllerBase
{
    private static List<Subject> _subjects = new();
    
    [HttpPost]
    public ActionResult<string> Create([FromBody] Subject subject)
    {
        throw new NotFoundException();
        // var id = _subjects.LastOrDefault()?.Id ?? 0;
        // subject.Id = id + 1;
        // _subjects.Add(subject);
        // return Ok(subject);
    }
}