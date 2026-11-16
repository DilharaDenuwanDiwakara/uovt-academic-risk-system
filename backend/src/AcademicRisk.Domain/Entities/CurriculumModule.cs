using AcademicRisk.Domain.Enums;

namespace AcademicRisk.Domain.Entities
{
    public class CurriculumModule
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; } = null!;
        public Guid ModuleId { get; set; }
        public Module Module { get; set; } = null!;
        public int SemesterNumber { get; set; }
        public int Credits { get; set; }
        public ModuleType ModuleType { get; set; }
        public GpaClassification GpaClassification { get; set; }

        public ICollection<StudentModuleEnrollment> Enrollments { get; set; } = new List<StudentModuleEnrollment>();
    }
}
