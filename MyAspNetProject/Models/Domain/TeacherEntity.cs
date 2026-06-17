namespace MyAspNetProject.Models.Domain;

public class TeacherEntity : UserEntity
{
    public Guid? HeadClassId { get; set; }
    public int Experience { get; set; }
    public decimal Salary { get; set; }
    public ICollection<SubjectEntity>? SubjectEntities { get; set; }
}
