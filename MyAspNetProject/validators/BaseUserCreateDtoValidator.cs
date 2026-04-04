using FluentValidation;
using MyAspNetProject.Models.Domain.Enums;
using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.validators;

public abstract class BaseUserCreateDtoValidator : AbstractValidator<BaseUserCreateDto>
{
    protected BaseUserCreateDtoValidator()
    {
        RuleFor(s => s.FirstName)
            .MinimumLength(3)
            .MaximumLength(30);

        RuleFor(s => s.LastName)
            .MinimumLength(3)
            .MaximumLength(30);

        RuleFor(s => s.Surname)
            .MinimumLength(3)
            .MaximumLength(30);

        RuleFor(x => x.Gender)
            .IsInEnum();

        RuleFor(x => x.ImageUrl)
            .Must(BaseUrlvalidator)
            .WithMessage("Url should contain http");

    }
    private bool BaseUrlvalidator(string? url)
    {
        string[] httpPrefixes = ["http", "https"];
        return ;
    }
}
