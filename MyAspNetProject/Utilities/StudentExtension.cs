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

    public static StudentEntity ToEntity(this StudentCreateDto dto)
    {
        return new StudentEntity
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Surname = dto.Surname,
            Password = dto.Password,
            KlassId = dto.KlassId,
            CreatedAt = DateTime.Now,
            Birthday = dto.Birthday,
            Email = dto.Email,
            Gender = dto.Gender,
            ImageUrl = dto.ImageUrl,
            Role = UserRoleEnum.Student,
            PhoneNumber = dto.PhoneNumber,
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