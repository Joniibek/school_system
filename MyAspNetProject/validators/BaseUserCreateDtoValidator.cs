using System.Text.RegularExpressions;
using FluentValidation;
using MyAspNetProject.Models.Domain.Enums;
using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.validators;

public abstract class BaseUserCreateDtoValidator<T> : AbstractValidator<T> where T : BaseUserCreateDto
{
    protected BaseUserCreateDtoValidator()
    {
        RuleFor(s => s.FirstName)
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(30);

        RuleFor(s => s.LastName)
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(30);

        RuleFor(s => s.Surname)
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(30);

        RuleFor(x => x.Gender)
            .NotNull()
            .IsInEnum();

        RuleFor(x => x.ImageUrl)
            .Must(BaseUrlvalidator)
            .When(x => x.ImageUrl is not null || !x.ImageUrl.IsWhiteSpace())
            .WithMessage("Url should starts with 'http' or 'https'");

        RuleFor(x => x.PhoneNumber)
            .NotNull()
            .Must(PhoneNumberValidator);

        RuleFor(x => x.Email)
            .NotNull()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotNull()
            .MinimumLength(5)
            .MaximumLength(8);
    }

    private bool PhoneNumberValidator(string phoneNumber)
    {
        return Regex.IsMatch(
            phoneNumber, 
            @"^(\+?\d{1,3})?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$"
            );
    }

    private bool BaseUrlvalidator(string? url)
    {
            return url!.StartsWith("http") || url.StartsWith("https");
    }
}
