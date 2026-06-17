using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MyAspNetProject.InfraStructure.Configurations;

namespace MyAspNetProject.InfraStructure;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.Models.Domain;



public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options)
    {
        Database.EnsureCreated();
    }

    public DbSet<KlassEntity> Klasses  { get; set; }
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<TeacherEntity> Teachers { get; set; }
    public DbSet<SubjectEntity> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=school_system;Username=postgres;Password=postgres"
            ).UseSnakeCaseNamingConvention();
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
    }
}