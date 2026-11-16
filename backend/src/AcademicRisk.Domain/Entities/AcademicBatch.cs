namespace AcademicRisk.Domain.Entities
{
    public class AcademicBatch
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; } = null!;
        public string BatchCode { get; set; } = string.Empty;
        public int IntakeYear { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<AcademicPeriod> AcademicPeriods { get; set; } = new List<AcademicPeriod>();
    }
}
