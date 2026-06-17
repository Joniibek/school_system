using System.Text.RegularExpressions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.InfraStructure;
using MyAspNetProject.Models.Domain.Enums;
using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.validators;

public abstract class BaseUserCreateDtoValidator<T>: AbstractValidator<T> where T : BaseUserCreateDto
{
    private readonly DBContext _dbContext;
    protected BaseUserCreateDtoValidator(DBContext dbContext)
    {
        _dbContext = dbContext;
        
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
            .Must(BaseUrlValidator)
            .When(x => x.ImageUrl is not null || !x.ImageUrl.IsWhiteSpace())
            .WithMessage("Url should starts with 'http' or 'https'");

        RuleFor(x => x.PhoneNumber)
            .NotNull().WithMessage("Номер телефона не указан")
            .Must(PhoneNumberRegexValidator).WithMessage("Невалидный номер телефона")
            .MustAsync(PhoneIsUniqueAsync).WithMessage("Пользователь с данным номером уже существует");

        RuleFor(x => x.Email)
            .NotNull()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotNull()
            .MinimumLength(5)
            .MaximumLength(8);
    }

    private bool PhoneNumberRegexValidator(string phoneNumber)
    {
        return Regex.IsMatch(
            phoneNumber, 
            @"^(\+?\d{1,3})?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$"
            );
    }

    private async Task<bool> PhoneIsUniqueAsync(string phoneNumber, 
        CancellationToken cancellationToken
        )
    {
        bool teacherPhoneExists = await _dbContext.Teachers
            .AsNoTracking()
            .AnyAsync(t => t.PhoneNumber == phoneNumber.Replace("+", ""));

        bool studentPhoneExists = await _dbContext.Students
            .AsNoTracking()
            .AnyAsync(s => s.PhoneNumber == phoneNumber);

        return !(teacherPhoneExists || studentPhoneExists);
    }

    private bool BaseUrlValidator(string? url)
    {
            return url!.StartsWith("http") || url.StartsWith("https");
    }
}
