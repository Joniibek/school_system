using MediatR;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;
using MyAspNetProject.Repositories;
using MyAspNetProject.Utilities;

namespace MyAspNetProject.Handlers;


public class KlassCreateHandler(IKlassRepository repository) : IRequestHandler<KlassCreateCommand, KlassCreateResponseDto>
{
    private IKlassRepository _repository = repository;

    public async Task<KlassCreateResponseDto> Handle(KlassCreateCommand request, CancellationToken cancellationToken)
    {
        KlassEntity klass = await _repository.Create(request.ToEntity());
        return new KlassCreateResponseDto
        {
            Id = klass.Id
        };
    }
}


public class KlassQueryHandler(IKlassRepository repository) : IRequestHandler<KlassListQuery, List<KlassListDto>>
{
    public async Task<List<KlassListDto>> Handle(KlassListQuery query, CancellationToken cancellationToken)
    {
        var klasses = await repository.GetAll(query.Group, query.Year);
         List<KlassListDto> klassResponseDto = new();
         foreach (var klass in klasses)
         {
             klassResponseDto.Add(klass.ToListDto());
         }
         return klassResponseDto;
    }
}