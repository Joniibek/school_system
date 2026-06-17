using MediatR;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Models.DTO.Request;

public record TeacherCreateCommand(
    KlassEntity? HeadClass, 
    int Experience, 
    decimal Salary
    ): BaseUserCreateDto, IRequest<TeacherShortListDto>;
    

public record TeacherSubjectsSetCommand(
    List<Guid> SubjectIds, Guid TeacherId): IRequest;