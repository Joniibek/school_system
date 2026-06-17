using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Utilities;

public static class KlassExtensions
{
    public static KlassEntity ToEntity(this KlassCreateCommand klassCreateCommand)
    {
        return new KlassEntity
        {
            Year = klassCreateCommand.Year,
            Group = klassCreateCommand.Group,
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