using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.Domain.Enums;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Utilities;

public static class StudentExtension
{
    public static StudentCreateResponseDto ToResponseDto(this StudentEntity studentEntity)
    {
        return new StudentCreateResponseDto
        {
            Id = studentEntity.Id
        };
    }

    public static StudentEntity ToEntity(this StudentCreateCommand command)
    {
        return new StudentEntity
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Surname = command.Surname,
            Password = command.Password,
            KlassId = command.KlassId,
            CreatedAt = DateTime.Now,
            Birthday = command.Birthday,
            Email = command.Email,
            Gender = command.Gender,
            ImageUrl = command.ImageUrl,
            Role = UserRoleEnum.Student,
            PhoneNumber = command.PhoneNumber,
            KlassEntity = null,
        };
    }

    public static StudentListDto ToListDto(this StudentEntity studentEntity)
    {
        return new StudentListDto
        {
            Id = studentEntity.Id,
            FirstName = studentEntity.FirstName,
            LastName = studentEntity.LastName,
            SurName = studentEntity.Surname,
            Klass = studentEntity.KlassEntity.ToListDto(),
        };
    }

    public static StudentDetailedListDto ToDetailedDto(this StudentEntity studentEntity)
    {
        return new StudentDetailedListDto
        {
            Id = studentEntity.Id,
            FirstName = studentEntity.FirstName,
            LastName = studentEntity.LastName,
            SurName = studentEntity.Surname,
            Klass = studentEntity.KlassEntity.ToListDto(),
            ImageUrl = studentEntity.ImageUrl,
            Birthday = studentEntity.Birthday,
            Email = studentEntity.Email,
            PhoneNumber = studentEntity.PhoneNumber,
            Performance = studentEntity.Performance,
        };

    }
}