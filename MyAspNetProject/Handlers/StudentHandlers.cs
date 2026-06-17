using MediatR;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;
using MyAspNetProject.Repositories;
using MyAspNetProject.Utilities;

namespace MyAspNetProject.Handlers;

// Command Handlers
public class StudentCreateCommandHandler(IStudentRepository repository): IRequestHandler<StudentCreateCommand, StudentCreateResponseDto>
{
    private readonly IStudentRepository _repository = repository;
    public async Task<StudentCreateResponseDto> Handle(StudentCreateCommand request, CancellationToken cancellationToken)
    {
        StudentEntity entity = await _repository.Create(request.ToEntity());
        return entity.ToResponseDto();
    }
}

// Query Handlers

public class StudentDetailedQueryHandler(IStudentRepository repository): IRequestHandler<StudentDetailedQuery, StudentDetailedListDto?>
{
    private readonly IStudentRepository _repository = repository;
    public async Task<StudentDetailedListDto?> Handle(StudentDetailedQuery query, CancellationToken cancellationToken)
    {
        StudentEntity? student =  await _repository.GetById(query.Id);
        return student?.ToDetailedDto();
    }
}


public class StudentListQueryHandler(IStudentRepository repository): IRequestHandler<StudentListQuery, List<StudentListDto>?>
{
    private readonly IStudentRepository _repository = repository;
    public async Task<List<StudentListDto>?> Handle(StudentListQuery query, CancellationToken cancellationToken)
    {
        var students = await _repository.List(query);
        List<StudentListDto> studentListDtos = new();
        foreach (var studentEntity in students)
        {
            studentListDtos.Add(studentEntity.ToListDto());
        }

        return studentListDtos;
    }
}


// public class StudentService(
//     IStudentRepository studentRepository, 
//     IKlassRepository klassRepository
//     ) : IStudentService
// {
//      private readonly IStudentRepository _studentRepository = studentRepository;
//      private readonly IKlassRepository _klassRepository = klassRepository;
//
//      public async Task<StudentDetailedListDto?> GetById(Guid id)
//      {
//          if (!(await _studentRepository.ExistsById(id)))
//          {
//              return null;
//          }
//          StudentEntity studentEntity = await _studentRepository.GetById(id);
//          return studentEntity.ToDetailedDto();
//      }
//
//      public async Task<List<StudentListDto>> List(StudentListQuery query)
//      {
//          List<StudentListDto> studentListDto = new();
//          List<StudentEntity> students = await _studentRepository.List(query);
//          foreach (var student in students)
//          {
//              studentListDto.Add(student.ToListDto());
//          }
//
//          return studentListDto;
//      }
//
//     public async Task<StudentCreateResponseDto?> Create(StudentCreateCommand studentCreateCommand)
//     {
//         if (!(await _klassRepository.ExistsById(studentCreateCommand.KlassId)))
//             return null;
//     
//         if (await _studentRepository.ExistsByCredentials(studentCreateCommand.Email, studentCreateCommand.PhoneNumber))
//             return null;
//     
//         StudentEntity? student = await _studentRepository.Create(studentCreateCommand.ToEntity());
//         return student.ToResponseDto();
//     }
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
// }