namespace MyAspNetProject.Models.DTO.Response;

public class TeacherShortListDto: BaseModelResponseDto
{
    public required string Name { get; set; }
}

public class TeacherListDto : BaseModelResponseDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string SurName { get; set; }
    public required string ImageUrl { get; set; }
    public required string PhoneNumber { get; set; }
    public List<SubjectListDto>? SubjectListDtos { get; set; }
}