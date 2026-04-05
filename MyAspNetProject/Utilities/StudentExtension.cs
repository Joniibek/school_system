using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.Domain.Enums;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Utilities;

public static class StudentExtension
{
    public static StudentCreateResponseDto ToResponseDto(this Student student)
    {
        return new StudentCreateResponseDto
        {
            Id = student.Id
        };
    }

    public static Student ToEntity(this StudentCreateDto dto, Klass klass)
    {
        return new Student
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Surname = dto.Surname,
            Password = dto.Password,
            Klass = klass,
            CreatedAt = DateTime.Now,
            // Birthday = dto.Birthday,
            Email = dto.Email,
            Gender = dto.Gender,
            ImageUrl = dto.ImageUrl,
            Role = UserRoleEnum.Student,
            PhoneNumber = dto.PhoneNumber,  
        };
    }

    public static StudentListDto ToListDto(this Student student)
    {
        return new StudentListDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            SurName = student.Surname,
            Klass = student.Klass.ToListDto(),
        };
    }
}