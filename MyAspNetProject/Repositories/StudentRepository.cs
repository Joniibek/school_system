using Microsoft.EntityFrameworkCore;
using MyAspNetProject.InfraStructure;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.Domain.Enums;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;
using Npgsql;

namespace MyAspNetProject.Repositories;

public interface IStudentRepository
{
    Task<List<StudentEntity>> List(StudentListQuery query);
    Task<StudentEntity> GetById(int id);

    Task<bool> ExistsById(int id);
    Task<bool> ExistsByCredentials(string email, string phone);
    Task<StudentEntity> Create(StudentEntity studentEntityCreateDto);
    // List<Student> GetByYear(int year);
    // List<Student> GetByKlass(int id);
}


public class StudentRepository(DBContext dbContext) : IStudentRepository
{
     private readonly DBContext _dbContext = dbContext;
     public async Task<List<StudentEntity>> List(StudentListQuery query)
     {
         IQueryable<StudentEntity> queryStudent = _dbContext.Students.Include(x => x.KlassEntity)
             .AsNoTracking();

         if (query.KlassId.HasValue)
         {
             queryStudent = queryStudent.Where(x => x.KlassId == query.KlassId);
         }

         if (query.Year.HasValue)
         {
             queryStudent = queryStudent.Where(x => x.KlassEntity.Year == query.Year);
         }

         return await queryStudent.Take(query.Limit).Skip(query.Offset).ToListAsync();
     }

     public async Task<StudentEntity> GetById(int id)
     {
         return await _dbContext.Students.
             AsNoTracking()
             .Include(s => s.KlassEntity)
             .FirstAsync(s => s.Id == id);
     }

     public async Task<StudentEntity> Create(StudentEntity entity)
     {
         entity.CreatedAt = entity.UpdatedAt = DateTime.UtcNow;
         var student = await _dbContext.Students.AddAsync(entity);
         await _dbContext.SaveChangesAsync();
         return student.Entity;
     }
//
//     public List<Student> GetByYear(int year)
//     {
//         return _dbContext.Students.Where(x => x.Klass.Year == year).ToList();
//     }
//
//     public List<Student> GetByKlass(int id)
//     {
//         return _dbContext.Students.Where(x => x.Klass.Id == id).ToList();
//     }
//
     public async Task<bool> ExistsByCredentials(string email, string phone)
     {
         return await _dbContext.Students.AnyAsync(x => x.Email == email || x.PhoneNumber == phone);
     }

     public async Task<bool> ExistsById(int id)
     {
         return await _dbContext.Students
             .AsNoTracking()
             .AnyAsync(s => s.Id == id);
     }

}