namespace AcademicRisk.Domain.Entities
{
    public class GradeDefinition
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; } = null!;
        public string GradeCode { get; set; } = string.Empty;
        public decimal? GradePoint { get; set; } // NULL until approved mapping is provided
        public int? MinimumMark { get; set; }
        public int? MaximumMark { get; set; }
        public bool? EarnsCredits { get; set; }
        public string? Description { get; set; }
    }
}
