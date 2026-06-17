using MyAspNetProject.Models.Domain.Enums;

namespace MyAspNetProject.Models.Domain;



public abstract class UserEntity: BaseEntityModel
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Surname { get; set; }
    public DateOnly Birthday { get; set; }
    public UserRoleEnum Role { get; set; }
    public UserGender Gender { get; set; }
    public required string ImageUrl { get; set; }
    public string? Email { get; set; }
    
    // Control for PhoneNumber field
    public required string PhoneNumber
    {
        get { return field;}
        set
        {
            field = value.Replace("+", "");
        }
    }

    public required string Password { get; set; }
}