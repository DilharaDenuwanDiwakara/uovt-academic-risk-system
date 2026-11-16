using AcademicRisk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicRisk.Infrastructure.Persistence.Configurations;

public sealed class StudentModuleResultConfiguration : IEntityTypeConfiguration<StudentModuleResult>
{
    public void Configure(EntityTypeBuilder<StudentModuleResult> b)
    {
        b.ToTable("student_module_results", t => t.HasCheckConstraint("CK_StudentModuleResults_AttemptNumber", "\"attempt_number\" >= 1"));

        b.HasKey(x => x.Id);

        b.Property(x => x.GradeCode).HasMaxLength(20);

        b.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        b.Property(x => x.Notes)
            .HasMaxLength(500);

        b.HasIndex(x => new { x.StudentModuleEnrollmentId, x.AttemptNumber })
            .IsUnique();

        b.HasOne(x => x.StudentModuleEnrollment)
            .WithMany(x => x.Results)
            .HasForeignKey(x => x.StudentModuleEnrollmentId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.ExaminationPeriod)
            .WithMany(x => x.ExaminationResults)
            .HasForeignKey(x => x.ExaminationPeriodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
