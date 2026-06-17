using System.Runtime.CompilerServices;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.InfraStructure;
using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.validators;

public class SubjectCreateValidator: AbstractValidator<SubjectCreateCommand>
{
    private DBContext _dbContext;
    public SubjectCreateValidator(DBContext dbContext)
    {
        _dbContext = dbContext;
        
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Название не указано")
            .MinimumLength(3).WithMessage("Недостаточно символов в названии")
            .MaximumLength(50).WithMessage("Превышено ограничение симоволов в названии")
            .MustAsync(async (name, cancellationToken) =>
            {
                bool subjectExists = await _dbContext.Subjects
                    .AsNoTracking()
                    .AnyAsync(s => s.Name == name);
                
                return !subjectExists;
            }).WithMessage("Предмет уже сущесвует");
    }
}