using MediatR;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Models.Query;

public record KlassListQuery(
    string? Group, int Year
    ) : IRequest<List<KlassListDto>>;