using AcademicRisk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicRisk.Infrastructure.Persistence.Configurations;

public sealed class CurriculumModuleConfiguration : IEntityTypeConfiguration<CurriculumModule>
{
    public void Configure(EntityTypeBuilder<CurriculumModule> b)
    {
        b.ToTable("curriculum_modules", t =>
        {
            t.HasCheckConstraint("CK_CurriculumModules_SemesterNumber", "\"semester_number\" BETWEEN 1 AND 6");

            t.HasCheckConstraint("CK_CurriculumModules_Credits", "\"credits\" > 0");
        });

        b.HasKey(x => x.Id);

        b.Property(x => x.ModuleType)
            .HasConversion<string>()
            .HasMaxLength(20);

        b.Property(x => x.GpaClassification)
            .HasConversion<string>().HasMaxLength(20);

        b.HasIndex(x => new { x.CurriculumId, x.ModuleId }).IsUnique();

        b.HasOne(x => x.Curriculum)
            .WithMany(x => x.CurriculumModules)
            .HasForeignKey(x => x.CurriculumId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.Module)
            .WithMany(x => x.CurriculumModules)
            .HasForeignKey(x => x.ModuleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
