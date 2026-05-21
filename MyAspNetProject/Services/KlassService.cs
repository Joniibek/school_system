using System.Data;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;
using MyAspNetProject.Repositories;
using MyAspNetProject.Utilities;

namespace MyAspNetProject.Services;

public interface IKlassService
{
    Task<List<KlassListDto>> List(KlassListQuery query);
    Task<KlassCreateResponseDto?> Create(KlassCreateDto klassCreateDto);
    Task Delete(int id);
}



public class KlassService(IKlassRepository repository) : IKlassService
{
    public async Task<List<KlassListDto>> List(KlassListQuery query)
    {
        var klasses = await repository.GetAll(query.Group, query.Year);
        List<KlassListDto> klassResponseDto = new();
        foreach (var klass in klasses)
        {
            klassResponseDto.Add(klass.ToListDto());
        }

        return klassResponseDto;
    }

    public async Task<KlassCreateResponseDto?> Create(KlassCreateDto klassCreateDto)
    {
        if (await repository.ExistsByYearGroup(klassCreateDto.Year, klassCreateDto.Group))
            return null;
        
        var klass = await repository.Create(klassCreateDto.ToEntity());
        return new KlassCreateResponseDto
        {
            Id = klass.Id,
        };
    }

    public async Task Delete(int id)
    {
        await repository.Delete(id);
    }
}
