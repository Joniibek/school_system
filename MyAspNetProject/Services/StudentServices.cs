using MyAspNetProject.Exceptions;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;
using MyAspNetProject.Repositories;
using MyAspNetProject.Utilities;

namespace MyAspNetProject.Services;

public interface IStudentService
{
    Task<StudentDetailedListDto?> GetById(int id);
    Task<List<StudentListDto>> List(StudentListQuery query);
    Task<StudentCreateResponseDto?> Create(StudentCreateDto studentCreateDto);
    // void Delete(int id);
    // List<StudentListDto> GetAllByYear(int year, string? group);
}

public class StudentService(
    IStudentRepository studentRepository, 
    IKlassRepository klassRepository
    ) : IStudentService
{
     private readonly IStudentRepository _studentRepository = studentRepository;
     private readonly IKlassRepository _klassRepository = klassRepository;

     public async Task<StudentDetailedListDto?> GetById(int id)
     {
         if (!(await _studentRepository.ExistsById(id)))
         {
             return null;
         }
         StudentEntity studentEntity = await _studentRepository.GetById(id);
         return studentEntity.ToDetailedDto();
     }

     public async Task<List<StudentListDto>> List(StudentListQuery query)
     {
         List<StudentListDto> studentListDto = new();
         List<StudentEntity> students = await _studentRepository.List(query);
         foreach (var student in students)
         {
             studentListDto.Add(student.ToListDto());
         }

         return studentListDto;
     }

    public async Task<StudentCreateResponseDto?> Create(StudentCreateDto studentCreateDto)
    {
        if (!(await _klassRepository.ExistsById(studentCreateDto.KlassId)))
            return null;
    
        if (await _studentRepository.ExistsByCredentials(studentCreateDto.Email, studentCreateDto.PhoneNumber))
            return null;
    
        StudentEntity? student = await _studentRepository.Create(studentCreateDto.ToEntity());
        return student.ToResponseDto();
    }
    //
    // public void Delete(int id)
    // {
    //    var student =  _studentRepository.GetById(id);
    //    if (student is null) throw new NotFoundException("Student", id);
    //    _studentRepository.Delete(student);
    // }
    //
    // public List<StudentListDto> GetAllByYear(int year, string? group)
    // {
    //     List<Student> students;
    //     if (group is not null && _klassRepository.ExistsByYearGroup(year, group))
    //     {
    //         Klass klass = _klassRepository.GetByYearAndGroup(year, group.ToUpper());
    //         students = _studentRepository.GetByKlass(klass.Id);
    //     }
    //     else
    //         students = _studentRepository.GetByYear(year);
    //     
    //     List<StudentListDto> studentsDto = new();
    //     foreach (var student in students)
    //     {
    //         studentsDto.Add(student.ToListDto());
    //     }
    //
    //     return studentsDto;
    // }
}