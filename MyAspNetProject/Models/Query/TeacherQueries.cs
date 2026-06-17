using MediatR;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Models.Query;

public record TeacherListQuery(
    Guid? SubjectId
    ) : BaseQuery, IRequest<List<TeacherListDto>>;