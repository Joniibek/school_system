using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Utilities;

public static class KlassExtensions
{
    public static KlassEntity ToEntity(this KlassCreateDto klassCreateDto)
    {
        return new KlassEntity
        {
            Year = klassCreateDto.Year,
            Group = klassCreateDto.Group,
        };
    }

    public static KlassListDto ToListDto(this KlassEntity klassEntity)
    {
        return new KlassListDto
        {
            Id = klassEntity.Id,
            Year = klassEntity.Year,
            Group = klassEntity.Group,
        };
    }
}