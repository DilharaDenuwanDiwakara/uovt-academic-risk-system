namespace AcademicRisk.Domain.Entities
{
    public class Module
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public ICollection<CurriculumModule> CurriculumModules { get; set; } = new List<CurriculumModule>();
    }
}
