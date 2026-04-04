using System.ComponentModel.DataAnnotations;
using MyAspNetProject.Models.Domain.Enums;

namespace MyAspNetProject.Models.DTO.Request;

public abstract class BaseUserCreateDto
{
    [Required]
    [MinLength(3)]
    public required string FirstName { get; set; }
    
    [Required]
    [MinLength(3)]
    public required string LastName { get; set; }

    [Required]
    [MinLength(5)]
    public required string Surname { get; set; }
    
    [Required]
    [MinLength(5)]
    public required string Email { get; set; }
    
    [Required] public UserGender Gender { get; set; }
    [Required] public required string Password { get; set; }
    // [Required] public DateOnly Birthday { get; set; }
    public string? ImageUrl { get; set; }
    public string? PhoneNumber { get; set; }
}