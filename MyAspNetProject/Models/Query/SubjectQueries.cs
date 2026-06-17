using MediatR;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Models.Query;

public record SubjectListQuery (
        Guid? TeacherId
    ): BaseQuery, IRequest<List<SubjectListDto>>;