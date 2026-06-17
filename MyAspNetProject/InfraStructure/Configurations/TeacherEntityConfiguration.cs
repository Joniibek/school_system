using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAspNetProject.Models.Domain;

namespace MyAspNetProject.InfraStructure.Configurations;

public class TeacherEntityConfiguration: IEntityTypeConfiguration<TeacherEntity>
{
    public void Configure(EntityTypeBuilder<TeacherEntity> builder)
    {
        builder.ToTable("teacher");
        builder.HasMany(t => t.SubjectEntities)
            .WithMany(s => s.Teachers)
            .UsingEntity(j => j.ToTable("subject_teacher"));
    }
}