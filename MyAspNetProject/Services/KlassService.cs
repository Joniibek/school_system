using System.Data;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Repositories;
using MyAspNetProject.Utilities;

namespace MyAspNetProject.Services;

public interface IKlassService
{
    KlassCreateResponseDto Create(KlassCreateDto klassCreateDto);
}



public class KlassService(IKlassRepository repository) : IKlassService
{
    public KlassCreateResponseDto Create(KlassCreateDto klassCreateDto)
    {
        if (repository.ExistsByYearGroup(klassCreateDto.Year, klassCreateDto.Group))
        {
            throw new ConstraintException(
                $"Klass with year {klassCreateDto.Year} and group {klassCreateDto.Group} already exists"
                );
        }
        var klass = repository.Create(klassCreateDto.ToEntity());
        return new KlassCreateResponseDto
        {
            Id = klass.Id
        };
    }
}