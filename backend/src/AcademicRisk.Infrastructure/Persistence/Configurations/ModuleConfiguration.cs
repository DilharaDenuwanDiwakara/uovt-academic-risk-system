using AcademicRisk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicRisk.Infrastructure.Persistence.Configurations;

public sealed class ModuleConfiguration : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> b)
    {
        b.ToTable("modules");

        b.HasKey(x => x.Id);

        b.Property(x => x.Code)
            .HasMaxLength(30)
            .IsRequired();

        b.Property(x => x.Title)
            .HasMaxLength(250)
            .IsRequired();

        b.HasIndex(x => x.Code).IsUnique();
    }
}
