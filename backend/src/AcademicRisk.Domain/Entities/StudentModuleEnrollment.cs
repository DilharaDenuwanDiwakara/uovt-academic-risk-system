namespace AcademicRisk.Domain.Entities
{
    public class StudentModuleEnrollment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public Guid CurriculumModuleId { get; set; }
        public CurriculumModule CurriculumModule { get; set; } = null!;
        public Guid AcademicPeriodId { get; set; }
        public AcademicPeriod AcademicPeriod { get; set; } = null!;
        public DateOnly? RegisteredOn { get; set; }
        public ICollection<StudentModuleResult> Results { get; set; } = new List<StudentModuleResult>();
    }
}
