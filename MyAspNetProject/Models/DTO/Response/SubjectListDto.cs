namespace MyAspNetProject.Models.DTO.Response;

public class SubjectListDto: BaseModelResponseDto
{
    public required string Name { get; set; }
    public List<TeacherShortListDto>? Teachers{ get; set; }
}