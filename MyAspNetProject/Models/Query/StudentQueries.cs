using MediatR;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Models.Query;


public record StudentDetailedQuery(Guid Id) : IRequest<StudentDetailedListDto?>;

public record StudentListQuery(
    Guid? KlassId, int? Year
    ) : BaseQuery, IRequest<List<StudentListDto>>;