using AcademicRisk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademicRisk.Infrastructure.Persistence
{
    public sealed class AcademicRiskDbContext(DbContextOptions<AcademicRiskDbContext> options) : DbContext(options)
    {
        public DbSet<AcademicProgramme> AcademicProgrammes => Set<AcademicProgramme>();
        public DbSet<Curriculum> Curricula => Set<Curriculum>();
        public DbSet<AcademicBatch> AcademicBatches => Set<AcademicBatch>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<AcademicPeriod> AcademicPeriods => Set<AcademicPeriod>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<CurriculumModule> CurriculumModules => Set<CurriculumModule>();
        public DbSet<GradeDefinition> GradeDefinitions => Set<GradeDefinition>();
        public DbSet<StudentModuleEnrollment> StudentModuleEnrollments => Set<StudentModuleEnrollment>();
        public DbSet<StudentModuleResult> StudentModuleResults => Set<StudentModuleResult>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcademicRiskDbContext).Assembly);
        }
    }
}
