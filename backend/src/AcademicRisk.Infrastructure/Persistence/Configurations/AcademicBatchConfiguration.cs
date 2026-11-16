using AcademicRisk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicRisk.Infrastructure.Persistence.Configurations;

public sealed class AcademicBatchConfiguration : IEntityTypeConfiguration<AcademicBatch>
{
    public void Configure(EntityTypeBuilder<AcademicBatch> b)
    {
        b.ToTable("academic_batches");

        b.HasKey(x => x.Id);

        b.Property(x => x.BatchCode)
            .HasMaxLength(30)
            .IsRequired();

        b.HasIndex(x => new { x.CurriculumId, x.IntakeYear, x.BatchCode }).IsUnique();

        b.HasOne(x => x.Curriculum)
            .WithMany(x => x.AcademicBatches)
            .HasForeignKey(x => x.CurriculumId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
