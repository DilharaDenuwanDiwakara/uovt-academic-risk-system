using AcademicRisk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicRisk.Infrastructure.Persistence.Configurations;

public sealed class StudentModuleEnrollmentConfiguration : IEntityTypeConfiguration<StudentModuleEnrollment>
{
    public void Configure(EntityTypeBuilder<StudentModuleEnrollment> b)
    {
        b.ToTable("student_module_enrollments");

        b.HasKey(x => x.Id);

        b.HasIndex(x => new { x.StudentId, x.CurriculumModuleId, x.AcademicPeriodId }).IsUnique();

        b.HasOne(x => x.Student)
            .WithMany(x => x.Enrollments)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.CurriculumModule)
            .WithMany(x => x.Enrollments)
            .HasForeignKey(x => x.CurriculumModuleId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.AcademicPeriod)
            .WithMany(x => x.Enrollments)
            .HasForeignKey(x => x.AcademicPeriodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
