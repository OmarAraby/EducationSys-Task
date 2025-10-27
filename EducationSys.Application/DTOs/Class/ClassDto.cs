namespace EducationSys.Application.DTOs.Class
{
    public class ClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Teacher { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
