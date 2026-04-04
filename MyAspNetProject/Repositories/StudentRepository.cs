using MyAspNetProject.Models.Domain;

namespace MyAspNetProject.Repositories;

public interface IStudentRepository: IBaseRepository<Student>
{
}


public class StudentRepository: BaseRepository<Student>, IStudentRepository
{
    
}