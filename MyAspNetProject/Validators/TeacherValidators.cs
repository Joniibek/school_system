using System.Runtime.InteropServices.Java;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.InfraStructure;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Repositories;

namespace MyAspNetProject.validators;

public class TeacherSubjectSetValidator : AbstractValidator<TeacherSubjectsSetCommand>
{
    private readonly DBContext _dbContext;
    public TeacherSubjectSetValidator(DBContext dbContext)
    {
        _dbContext = dbContext;
        RuleFor(s => s.TeacherId)
            .NotEmpty().WithMessage("Учитель не указан")
            .MustAsync(async (teacherId, ct) =>
            {
                return await _dbContext.Teachers
                    .AsNoTracking()
                    .AnyAsync(t => t.Id == teacherId, ct);
            }).WithMessage("Учитель не найден");

        RuleForEach(s => s.SubjectIds)
            .NotEmpty().WithMessage("Предметы не указаны")
            .MustAsync(async (subjectId, ct) =>
            {
                return await _dbContext.Subjects
                    .AsNoTracking()
                    .AnyAsync(s => s.Id == subjectId);
            }).WithMessage("Предмет(ы) не найдены");
    }
}