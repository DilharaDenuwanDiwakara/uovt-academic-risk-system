using AcademicRisk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicRisk.Infrastructure.Persistence.Configurations;

public sealed class AcademicPeriodConfiguration : IEntityTypeConfiguration<AcademicPeriod>
{
    public void Configure(EntityTypeBuilder<AcademicPeriod> b)
    {
        b.ToTable("academic_periods", t => t.HasCheckConstraint("CK_AcademicPeriods_SemesterNumber", "\"semester_number\" BETWEEN 1 AND 6"));

        b.HasKey(x => x.Id);

        b.Property(x => x.Label).HasMaxLength(100);

        b.HasIndex(x => new { x.AcademicBatchId, x.SemesterNumber })
            .IsUnique();

        b.HasOne(x => x.AcademicBatch)
            .WithMany(x => x.AcademicPeriods)
            .HasForeignKey(x => x.AcademicBatchId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
