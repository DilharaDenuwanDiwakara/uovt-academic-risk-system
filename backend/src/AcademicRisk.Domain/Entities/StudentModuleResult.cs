using AcademicRisk.Domain.Enums;

namespace AcademicRisk.Domain.Entities
{
    public class StudentModuleResult
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid StudentModuleEnrollmentId { get; set; }
        public StudentModuleEnrollment StudentModuleEnrollment { get; set; } = null!;
        public Guid ExaminationPeriodId { get; set; }
        public AcademicPeriod ExaminationPeriod { get; set; } = null!;
        public int AttemptNumber { get; set; }
        public string? GradeCode { get; set; } // e.g. A, D, F(ET), I(ET), Pass
        public ResultStatus Status { get; set; } = ResultStatus.Pending;
        public bool HasAcademicConcession { get; set; }
        public DateOnly? PublishedOn { get; set; }
        public string? Notes { get; set; }
    }
}
