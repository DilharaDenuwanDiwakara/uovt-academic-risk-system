using AcademicRisk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicRisk.Infrastructure.Persistence.Configurations;

public sealed class AcademicProgrammeConfiguration : IEntityTypeConfiguration<AcademicProgramme>
{
    public void Configure(EntityTypeBuilder<AcademicProgramme> b)
    {
        b.ToTable("academic_programmes");

        b.HasKey(x => x.Id);

        b.Property(x => x.Code)
            .HasMaxLength(30)
            .IsRequired();

        b.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        b.HasIndex(x => x.Code).IsUnique();
    }
}
