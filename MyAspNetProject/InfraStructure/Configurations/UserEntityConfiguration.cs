using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAspNetProject.Models.Domain;

namespace MyAspNetProject.InfraStructure.Configurations;

public class UserEntityConfiguration: IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(30);
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(30);
        builder.Property(u => u.Surname)
            .HasMaxLength(30);
        builder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(13);
        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(10);
        builder.Property(u => u.Email)
            .HasMaxLength(50);
        builder.Property(u => u.Gender)
            .IsRequired();
        builder.Property(u => u.Role)
            .IsRequired();
        builder.Property(u => u.ImageUrl)
            .IsRequired()
            .HasMaxLength(200);
        
        // Indexes
        builder.HasIndex(u => u.Email)
            .IsUnique();
        builder.HasIndex(u => u.PhoneNumber)
            .IsUnique();
    }
}