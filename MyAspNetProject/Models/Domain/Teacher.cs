namespace MyAspNetProject.Models.Domain;

public class Teacher : User
{
    public Сlass? HeadClass { get; set; }
    public int Experience { get; set; }
}


public class TeacherSubject
{
    public required Subject SubjectId { get; set; }
    public required Teacher TeacherId { get; set; }
}