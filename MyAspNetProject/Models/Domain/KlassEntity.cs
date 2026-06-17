namespace MyAspNetProject.Models.Domain;

public class KlassEntity: BaseEntityModel
{
    public int Year { get; set; }
    public required string Group { get; set; }
    public ICollection<StudentEntity> Students { get; set; }
}