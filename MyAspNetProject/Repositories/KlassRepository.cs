using Microsoft.EntityFrameworkCore;
using MyAspNetProject.InfraStructure;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using Npgsql;

namespace MyAspNetProject.Repositories;


public interface IKlassRepository
{
    Task<List<KlassEntity>> GetAll(string? group, int? year);
    Task<KlassEntity> Create(KlassEntity entity);
    Task<bool> ExistsByYearGroup(int? year, string? group);
    Task<KlassEntity> GetByYearAndGroup(int year, string group);
    Task<bool> ExistsById(int id);
    Task Delete(int id);
}




public class KlassRepository(DBContext dbContext) :IKlassRepository
{
    private readonly DBContext _dbContext = dbContext;

    public async Task<List<KlassEntity>> GetAll(string? group, int? year)
    {
        IQueryable<KlassEntity> query = _dbContext.Klasses.AsNoTracking();
        
        if (!string.IsNullOrWhiteSpace(group))
            query = query.Where(k => k.Group == group);
        if (year.HasValue)
            query = query.Where(k => k.Year == year.Value);
        
        return await query.ToListAsync();
    }
    public async Task<KlassEntity> Create(KlassEntity entity)
    {
        entity.CreatedAt = entity.UpdatedAt = DateTime.UtcNow;
        var klass = await _dbContext.Klasses.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return klass.Entity;
    }

    public async Task<bool> ExistsByYearGroup(int? year, string? group)
    {
        return await _dbContext.Klasses
            .AsNoTracking()
            .AnyAsync(klass => klass.Year == year && klass.Group == group); 
    }

   public async Task<KlassEntity> GetByYearAndGroup(int year, string group)
   {

       return await _dbContext.Klasses
           .AsNoTracking()
           .FirstAsync(k => k.Group == group && k.Year == year);
   }

   public async Task<bool> ExistsById(int id)
   {
       return await _dbContext.Klasses
           .AsNoTracking()
           .AnyAsync(k => k.Id == id);
   }

   public async Task Delete(int id)
   { 
       await _dbContext.Klasses.Where(k => k.Id == id).ExecuteDeleteAsync();
   }
}
