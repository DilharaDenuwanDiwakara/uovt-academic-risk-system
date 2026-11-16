using AcademicRisk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicRisk.Infrastructure.Persistence.Configurations;

public sealed class GradeDefinitionConfiguration : IEntityTypeConfiguration<GradeDefinition>
{
    public void Configure(EntityTypeBuilder<GradeDefinition> b)
    {
        b.ToTable("grade_definitions");

        b.HasKey(x => x.Id);

        b.Property(x => x.GradeCode)
            .HasMaxLength(20)
            .IsRequired();

        b.Property(x => x.GradePoint)
            .HasPrecision(4, 2);

        b.Property(x => x.Description)
            .HasMaxLength(250);

        b.HasIndex(x => new { x.CurriculumId, x.GradeCode })
            .IsUnique();

        b.HasOne(x => x.Curriculum)
            .WithMany(x => x.GradeDefinitions)
            .HasForeignKey(x => x.CurriculumId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
