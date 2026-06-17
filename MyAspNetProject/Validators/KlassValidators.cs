using System.Text.RegularExpressions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.InfraStructure;
using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.validators;

public class KlassCreateDtoValidator : AbstractValidator<KlassCreateCommand>
{
    private readonly DBContext _dbContext;
    public KlassCreateDtoValidator(DBContext dbcontext)
    {
        _dbContext = dbcontext;
        
        RuleFor(x => x.Group)
            .Must(CheckKlassGroup).WithMessage("Невалидная буква параллели");

        RuleFor(x => x.Year)
            .GreaterThan(0).WithMessage("Невалидный год обучения")
            .LessThan(12).WithMessage("Невалидный год обучения")
            .MustAsync(async (model, year, cancellation) =>
            {
                return !await _dbContext.Klasses
                    .AsNoTracking()
                    .AnyAsync(klass => klass.Year == year && klass.Group == model.Group, cancellation);
            }).WithMessage("Класс с такими данными уже сущесвует");
    }

    private bool CheckKlassGroup(string group)
    {
        return Regex.IsMatch(group, @"[А-ЯёË]$");
    }
}