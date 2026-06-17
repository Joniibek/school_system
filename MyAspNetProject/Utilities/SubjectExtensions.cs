using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Utilities;

public static class SubjectExtensions
{
    public static SubjectEntity ToEntity(this SubjectCreateCommand data)
    {
        return new SubjectEntity
        {
            Name = data.Name,
        };
    }

    public static SubjectListDto ToListDto(this SubjectEntity entity)
    {
        List<TeacherShortListDto> teachers = new();
        foreach (var teacher in entity.Teachers)
        {
            teachers.Add(teacher.ToShortListDto());
        }
        
        return new SubjectListDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Teachers = teachers,
        };
    }
}