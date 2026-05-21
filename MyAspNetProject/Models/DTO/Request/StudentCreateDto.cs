using System.ComponentModel.DataAnnotations;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.Domain.Enums;

namespace MyAspNetProject.Models.DTO.Request;

public class StudentCreateDto: BaseUserCreateDto
{
    public int KlassId { get; set; }
}

public class StudentUpdateDto : BaseUserUpdateDto {}