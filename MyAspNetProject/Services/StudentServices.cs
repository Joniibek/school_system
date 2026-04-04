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
    StudentCreateResponseDto Create(StudentCreateDto studentDto);
}

public class StudentGetService(IStudentRepository studentRepository) : IStudentService
{
    private readonly IStudentRepository _repository = studentRepository;

    public Student? GetById(int id)
    {
        var student = _repository.GetById(id);
        return student ?? throw new NotFoundException();
    }

    public List<Student> GetAll()
    {
        return _repository.GetAll();
    }

    public StudentCreateResponseDto Create(StudentCreateDto studentDto)
    {
        Student? student = _repository.Create(studentDto.ToEntity());
        return student.ToResponseDto();

    }
}