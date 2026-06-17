namespace MyAspNetProject.Models.Domain;

public class SubjectEntity: BaseEntityModel
{
    public required string Name { get; set; }

    public ICollection<TeacherEntity>? Teachers { get; set; }
}