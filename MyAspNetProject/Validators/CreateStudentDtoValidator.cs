using FluentValidation;
using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.validators;

public class CreateStudentDtoValidator : BaseUserCreateDtoValidator<StudentCreateDto>
{
    public CreateStudentDtoValidator()
    {
        RuleFor(x => x.KlassId)
            .GreaterThan(0);
    }
}