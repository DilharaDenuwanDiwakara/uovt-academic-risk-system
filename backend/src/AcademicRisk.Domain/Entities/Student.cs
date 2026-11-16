namespace AcademicRisk.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string StudentKey { get; set; } = string.Empty;
        public Guid AcademicBatchId { get; set; }
        public AcademicBatch AcademicBatch { get; set; } = null!;
        public ICollection<StudentModuleEnrollment> Enrollments { get; set; } = new List<StudentModuleEnrollment>();
    }
}
