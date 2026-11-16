namespace AcademicRisk.Domain.Entities
{
    public class AcademicProgramme
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public ICollection<Curriculum> Curricula { get; set; } = new List<Curriculum>();
    }
}
