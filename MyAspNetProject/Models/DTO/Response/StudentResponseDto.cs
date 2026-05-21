using MyAspNetProject.Models.Domain.Enums;
using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.Models.DTO.Response;

public class StudentCreateResponseDto : BaseModelResponseDto {}

public class StudentListDto : BaseModelResponseDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? SurName { get; set; }
    public required KlassListDto Klass { get; set; }
}

public class StudentDetailedListDto : BaseModelResponseDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? SurName { get; set; }
    public required KlassListDto Klass { get; set; }
    public string? ImageUrl { get; set; }
    public string? Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateOnly Birthday { get; set; }
    public StudentPerformance? Performance { get; set; }
}
