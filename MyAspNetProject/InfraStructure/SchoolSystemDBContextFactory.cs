using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyAspNetProject.InfraStructure;

public class SchoolSystemDbContextFactory: IDesignTimeDbContextFactory<DBContext>
{
    public DBContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<DBContext>();
        optionBuilder.UseNpgsql(
"Host=localhost;Port=5432;Database=school_system;Username=postgres;Password=postgres"
            ).UseSnakeCaseNamingConvention();
        
        return new DBContext(optionBuilder.Options);
    }
}