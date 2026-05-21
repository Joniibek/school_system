using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAspNetProject.Models.Domain;

namespace MyAspNetProject.InfraStructure.Configurations;

public class StudentEntityConfiguration: IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.ToTable("student");
        builder.HasOne(x => x.KlassEntity)
            .WithMany(x => x.Students)
            .HasForeignKey(x => x.KlassId);
    }
}