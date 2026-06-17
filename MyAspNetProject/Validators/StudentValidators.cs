using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.InfraStructure;
using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.validators;

public class StudentCreateDtoValidator : BaseUserCreateDtoValidator<StudentCreateCommand>
{
    private DBContext _dbContext;
    public StudentCreateDtoValidator(DBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;

        RuleFor(x => x.KlassId)
            .NotNull().WithMessage("Класс студента не указан")
            .MustAsync(async (klassId, ct) =>
            {
                bool klassExists = await _dbContext.Klasses.AnyAsync(k => k.Id == klassId);
                return klassExists;
            }).WithMessage("Класс не найден");
    }
}