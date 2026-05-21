
using MyAspNetProject.Models.Domain.Enums;

namespace MyAspNetProject.Models.Domain;


public class StudentEntity: UserEntity
{
    public required int KlassId { get; set; }
    public StudentPerformance? Performance { get; set; }
    public required KlassEntity KlassEntity { get; set; }
}