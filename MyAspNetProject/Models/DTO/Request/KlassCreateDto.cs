using System.ComponentModel.DataAnnotations;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Models.DTO.Request;

public class KlassCreateDto
{
    public int Year  { get; set; }
    public required string Group { get; set; }
}
