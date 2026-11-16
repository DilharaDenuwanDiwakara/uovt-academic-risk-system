namespace AcademicRisk.Domain.Entities
{
    public class Curriculum
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AcademicProgrammeId { get; set; }
        public AcademicProgramme AcademicProgramme { get; set; } = null!;
        public string Version { get; set; } = string.Empty;
        public string? Description { get; set; }

        public ICollection<CurriculumModule> CurriculumModules { get; set; } = new List<CurriculumModule>();
        public ICollection<AcademicBatch> AcademicBatches { get; set; } = new List<AcademicBatch>();
        public ICollection<GradeDefinition> GradeDefinitions { get; set; } = new List<GradeDefinition>();



    }
}
