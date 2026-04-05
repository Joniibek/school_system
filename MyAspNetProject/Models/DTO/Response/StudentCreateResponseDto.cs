using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.Models.DTO.Response;

public class StudentCreateResponseDto
{
    public int Id { get; set; }
}

public class StudentListDto
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? SurName { get; set; }
    public required KlassListDto Klass { get; set; }
}