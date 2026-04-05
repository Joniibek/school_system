using MyAspNetProject.Exceptions;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Repositories;
using MyAspNetProject.Utilities;

namespace MyAspNetProject.Services;

public interface IStudentService
{
    Student? GetById(int id);
    List<Student> GetAll();
    StudentCreateResponseDto Create(StudentCreateDto studentCreateDto);
    void Delete(int id);
    List<StudentListDto> GetAllByYear(int year, string? group);
}

public class StudentGetService(
    IStudentRepository studentRepository, 
    IKlassRepository klassRepository
    ) : IStudentService
{
    private readonly IStudentRepository _studentRepository = studentRepository;
    private readonly IKlassRepository _klassRepository = klassRepository;

    public Student? GetById(int id)
    {
        var student = _studentRepository.GetById(id);
        return student;
    }

    public List<Student> GetAll()
    {
        return _studentRepository.GetAll();
    }

    public StudentCreateResponseDto Create(StudentCreateDto studentCreateDto)
    {
        if (!_klassRepository.ExistsById(studentCreateDto.KlassId))
        {
            throw new NotFoundException("Klass", studentCreateDto.KlassId);
        }

        var klass = _klassRepository.GetById(studentCreateDto.KlassId);
        Student? student = _studentRepository.Create(studentCreateDto.ToEntity(klass!));
        return student.ToResponseDto();
    }

    public void Delete(int id)
    {
       var student =  _studentRepository.GetById(id);
       if (student is null) throw new NotFoundException("Student", id);
       _studentRepository.Delete(student);
    }

    public List<StudentListDto> GetAllByYear(int year, string? group)
    {
        List<Student> students = new();
        if (group is not null && _klassRepository.ExistsByYearGroup(year, group))
        {
            Klass klass = _klassRepository.GetByYearAndGroup(year, group);
            students = _studentRepository.GetByKlass(klass.Id);
        }
        else
        {
            students = _studentRepository.GetByYear(year);
        }
        List<StudentListDto> studentsDto = new();
        foreach (var student in students)
        {
            studentsDto.Add(student.ToListDto());
        }

        return studentsDto;
    }
}