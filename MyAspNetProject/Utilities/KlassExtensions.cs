using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.Utilities;

public static class KlassExtensions
{
    public static Klass ToEntity(this KlassCreateDto klassCreateDto)
    {
        return new Klass
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Year = klassCreateDto.Year,
            Group = klassCreateDto.Group,
        };
    }
}