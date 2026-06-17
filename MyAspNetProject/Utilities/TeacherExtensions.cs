using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.Domain.Enums;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Repositories;

namespace MyAspNetProject.Utilities;

public static class TeacherExtensions
{
    public static TeacherEntity ToEntity(this TeacherCreateCommand command)
    {
        return new TeacherEntity
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Surname = command.Surname,
            Password = command.Password,
            CreatedAt = DateTime.Now,
            Experience = command.Experience,
            Birthday = command.Birthday,
            Email = command.Email,
            Gender = command.Gender,
            ImageUrl = command.ImageUrl,
            Role = UserRoleEnum.Student,
            PhoneNumber = command.PhoneNumber,
            Salary = command.Salary,
        };
    }

    public static TeacherShortListDto ToShortListDto(this TeacherEntity entity)
    {
        return new TeacherShortListDto
        {
            Id = entity.Id,
            Name = $"{entity.LastName} {entity.FirstName} {entity.Surname}",
        };
    }

    public static TeacherListDto ToDto(this TeacherEntity entity)
    {
        List<SubjectListDto> subjectListDtos = new();
        if (entity.SubjectEntities is not null)
        {
            foreach (var subjectEntity in entity.SubjectEntities)
            {
                subjectListDtos.Add(subjectEntity.ToListDto());
            }
        }
        return new TeacherListDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            SurName = entity.Surname,
            ImageUrl = entity.ImageUrl,
            PhoneNumber = entity.PhoneNumber,
            SubjectListDtos = subjectListDtos,
        };
    }
}