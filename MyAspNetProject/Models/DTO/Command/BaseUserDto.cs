using System.ComponentModel.DataAnnotations;
using MyAspNetProject.Models.Domain.Enums;

namespace MyAspNetProject.Models.DTO.Request;

public abstract record BaseUserCreateDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public UserGender Gender { get; set; }
    public required string Password { get; set; }
    public DateOnly Birthday { get; set; }
    public required string ImageUrl { get; set; }
    public required string PhoneNumber { get; set; }
}

public abstract record BaseUserUpdateDto: BaseUserCreateDto{}