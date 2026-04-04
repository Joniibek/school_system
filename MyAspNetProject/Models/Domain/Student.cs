
using MyAspNetProject.Models.Domain.Enums;

namespace MyAspNetProject.Models.Domain;


public class Student: User
{
    public int KlassId{ get; set; }
    public StudentPerformance? Performance { get; set; }
}