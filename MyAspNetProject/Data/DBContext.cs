using Microsoft.Extensions.Options;

namespace MyAspNetProject.InfraStructure;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.Models.Domain;



public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DbContext> options)
    {
        Database.EnsureCreated();
    }

    public DbSet<KlassEntity> Klasses  { get; set; }
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<SubjectEntity> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=school_system;Username=postgres;Password=postgres"
            );
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KlassEntity>().ToTable("klass");
        modelBuilder.Entity<Teacher>().ToTable("teacher");
        modelBuilder.Entity<StudentEntity>().ToTable("student");
        modelBuilder.Entity<SubjectEntity>().ToTable("subject");

        modelBuilder.Entity<KlassEntity>().Property(x => x.Group).HasMaxLength(1);
        modelBuilder.Entity<StudentEntity>()
            .HasOne(s => s.KlassEntity)
            .WithMany(k => k.Students)
            .HasForeignKey(s => s.KlassId);
        
        
        base.OnModelCreating(modelBuilder);
    }
}