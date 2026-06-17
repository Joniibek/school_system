using System.Runtime.InteropServices.JavaScript;

namespace MyAspNetProject.Models.Domain;

public abstract class BaseEntityModel
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}