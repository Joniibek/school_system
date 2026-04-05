using MyAspNetProject.Models.Domain;

namespace MyAspNetProject.Repositories;

public interface IStudentRepository: IBaseRepository<Student>
{
    List<Student> GetByYear(int year);
    List<Student> GetByKlass(int id);
}


public class StudentRepository: BaseRepository<Student>, IStudentRepository
{
    public List<Student> GetByYear(int year)
    {
        return Entities.Where(x => x.Klass.Year == year).ToList();
    }

    public List<Student> GetByKlass(int id)
    {
        return Entities.Where(x => x.Klass.Id == id).ToList();
    }
}