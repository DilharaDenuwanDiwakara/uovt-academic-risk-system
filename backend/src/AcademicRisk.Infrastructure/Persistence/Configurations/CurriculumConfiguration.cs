using AcademicRisk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicRisk.Infrastructure.Persistence.Configurations;

public sealed class CurriculumConfiguration : IEntityTypeConfiguration<Curriculum>
{
    public void Configure(EntityTypeBuilder<Curriculum> b)
    {
        b.ToTable("curricula");

        b.HasKey(x => x.Id);

        b.Property(x => x.Version)
            .HasMaxLength(40)
            .IsRequired();

        b.Property(x => x.Description)
            .HasMaxLength(500);

        b.HasIndex(x => new { x.AcademicProgrammeId, x.Version })
            .IsUnique();

        b.HasOne(x => x.AcademicProgramme)
            .WithMany(x => x.Curricula)
            .HasForeignKey(x => x.AcademicProgrammeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
