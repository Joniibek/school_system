using Microsoft.EntityFrameworkCore;
using MyAspNetProject.InfraStructure;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;
using Serilog.Debugging;

namespace MyAspNetProject.Repositories;

public interface ISubjectRepository
{
    Task<SubjectEntity> Create(SubjectEntity entity);
    Task<List<SubjectEntity>> List(SubjectListQuery query);
    Task<List<SubjectEntity>> GetMany(List<Guid> ids);
    Task<bool> ExistsManyAsync(List<Guid> ids);
}



public class SubjectRepository(DBContext dbContext): ISubjectRepository
{
    private DBContext _dbContext = dbContext;

    public async Task<SubjectEntity> Create(SubjectEntity entity)
    {
        var subject = await _dbContext.Subjects.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return subject.Entity;
    }

    public async Task<List<SubjectEntity>> List(SubjectListQuery query)
    {

        IQueryable<SubjectEntity> stmt = _dbContext.Subjects
            .AsNoTracking();
        
        if (query.TeacherId.HasValue)
        {
            stmt = stmt.Include(s => s.Teachers!
                .Where(t => t.Id == query.TeacherId)
            );
        }

        return await stmt
            .Include(s => s.Teachers)
            .Skip(query.Offset)
            .Take(query.Limit)
            .ToListAsync();
    }

    public async Task<List<SubjectEntity>> GetMany(List<Guid> ids)
    {
        return await _dbContext.Subjects
            .AsNoTracking()
            .Where(s => ids.Contains(s.Id))
            .ToListAsync();
    }

    public async Task<bool> ExistsManyAsync(List<Guid> ids)
    {
        var count = await _dbContext.Subjects
            .AsNoTracking()
            .CountAsync(x => ids.Contains(x.Id));

        return count == ids.Count();
    }
}