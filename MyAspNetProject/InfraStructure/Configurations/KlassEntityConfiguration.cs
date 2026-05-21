using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAspNetProject.Models.Domain;

namespace MyAspNetProject.InfraStructure;

public class  KlassEntityConfiguration: IEntityTypeConfiguration<KlassEntity>
{
    public void Configure(EntityTypeBuilder<KlassEntity> builder)
    {
        builder.ToTable("klass");
        builder.Property(x => x.Group).HasMaxLength(1);
    }
}