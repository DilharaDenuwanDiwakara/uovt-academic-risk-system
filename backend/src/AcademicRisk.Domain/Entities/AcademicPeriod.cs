namespace AcademicRisk.Domain.Entities
{
    public class AcademicPeriod
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AcademicBatchId { get; set; }
        public AcademicBatch AcademicBatch { get; set; } = null!;
        public int SemesterNumber { get; set; }
        public string? Label { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public ICollection<StudentModuleEnrollment> Enrollments { get; set; } = new List<StudentModuleEnrollment>();
        public ICollection<StudentModuleResult> ExaminationResults { get; set; } = new List<StudentModuleResult>();
    }
}
