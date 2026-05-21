namespace MyAspNetProject.Models.Domain;

public class SubjectEntity: BaseEntityModel
{
    public required string Name { get; set; }
    public List<int> TeacherIds { get; set; }
    public List<Teacher> Teachers { get; set; }
}