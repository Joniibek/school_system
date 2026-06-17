using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.Exceptions;
using MyAspNetProject.InfraStructure;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;

namespace MyAspNetProject.Repositories;

public interface ITeacherRepository
{
    Task<TeacherEntity> Create(TeacherEntity data);
    Task SetSubjects(Guid teacherId, List<SubjectEntity> subjectEntities);
    Task<List<TeacherEntity>> List(TeacherListQuery query);
}


public class TeacherRepository(DBContext dbContext) : ITeacherRepository
{
    private readonly DBContext _dbContext = dbContext;

    public async Task<TeacherEntity> Create(TeacherEntity data)
    {
        data.CreatedAt = data.UpdatedAt = DateTime.UtcNow;
        var query = await _dbContext.Teachers
            .AddAsync(data);
        
        await _dbContext.SaveChangesAsync();
        return query.Entity;
    }

    public async Task SetSubjects(Guid teacherId, List<SubjectEntity> subjectEntities)
    {
        TeacherEntity teacherEntity = await _dbContext.Teachers
            .FirstAsync(t => t.Id == teacherId);
        
        teacherEntity.SubjectEntities = subjectEntities;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<TeacherEntity>> List(TeacherListQuery query)
    {
        IQueryable<TeacherEntity> stmt = _dbContext.Teachers
            .AsNoTracking();

        if (query.SubjectId.HasValue)
        {
            stmt = stmt.Include(t =>
                t.SubjectEntities!.Where(s => s.Id == query.SubjectId));
        }

        return await stmt.Skip(query.Offset).Take(query.Limit).ToListAsync();
    }
}