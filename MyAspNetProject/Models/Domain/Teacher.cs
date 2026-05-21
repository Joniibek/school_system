namespace MyAspNetProject.Models.Domain;

public class Teacher : UserEntity
{
    public KlassEntity? HeadClass { get; set; }
    public int Experience { get; set; }
    public decimal Salary { get; set; }
    public List<int> SubjectIds { get; set; }
    public ICollection<SubjectEntity> SubjectEntities { get; set; }
}
