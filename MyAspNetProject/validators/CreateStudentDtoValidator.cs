using FluentValidation;
using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.validators;

public class CreateStudentDtoValidator : AbstractValidator<StudentCreateDto>
{
    public CreateStudentDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name cannot be empty");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithMessage("Surname cannot be empty");
    }
}