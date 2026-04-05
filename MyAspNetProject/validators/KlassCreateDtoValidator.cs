using System.Text.RegularExpressions;
using FluentValidation;
using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.validators;

public class KlassCreateDtoValidator : AbstractValidator<KlassCreateDto>
{
    public KlassCreateDtoValidator()
    {
        RuleFor(x => x.Group)
            .Must(CheckKlassGroup);

        RuleFor(x => x.Year)
            .GreaterThan(0)
            .LessThan(12);
    }

    private bool CheckKlassGroup(string group)
    {
        return Regex.IsMatch(group, @"[а-яА-ЯёË]$");
    }
}