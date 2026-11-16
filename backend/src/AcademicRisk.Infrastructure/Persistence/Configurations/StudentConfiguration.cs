using AcademicRisk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicRisk.Infrastructure.Persistence.Configurations;

public sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> b)
    {
        b.ToTable("students");

        b.HasKey(x => x.Id);

        b.Property(x => x.StudentKey)
            .HasMaxLength(64)
            .IsRequired();

        b.HasIndex(x => x.StudentKey).IsUnique();

        b.HasOne(x => x.AcademicBatch)
            .WithMany(x => x.Students)
            .HasForeignKey(x => x.AcademicBatchId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
