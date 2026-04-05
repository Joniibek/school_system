using MyAspNetProject.Models.Domain.Enums;

namespace MyAspNetProject.Models.Domain;




public abstract class User: BaseModel
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Surname { get; set; }
    public DateOnly Birthday { get; set; }
    public UserRoleEnum Role { get; set; }
    public UserGender Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
}