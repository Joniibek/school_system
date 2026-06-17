using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAspNetProject.Models.Domain;

namespace MyAspNetProject.InfraStructure.Configurations;


public class LessonEntityConfiguration: IEntityTypeConfiguration<SubjectEntity>
{
    public void Configure(EntityTypeBuilder<SubjectEntity> builder)
    {
        builder.ToTable("subject");
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.HasIndex(s => s.Name)
            .IsUnique();
    }
}