using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyAspNetProject.InfraStructure;

public class SchoolSystemDbContextFactory: IDesignTimeDbContextFactory<DBContext>
{
    public DBContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<DbContext>();
        optionBuilder.UseNpgsql(
"Host=localhost;Port=5432;Database=osoneats_entity_framework;Username=postgres;Password=postgres"
            );
        return new DBContext(optionBuilder.Options);
    }
}