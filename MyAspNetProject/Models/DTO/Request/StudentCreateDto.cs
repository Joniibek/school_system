using System.ComponentModel.DataAnnotations;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.Domain.Enums;

namespace MyAspNetProject.Models.DTO.Request;

public class StudentCreateDto: BaseUserCreateDto
{
    [Required] public int KlassId { get; set; }
}