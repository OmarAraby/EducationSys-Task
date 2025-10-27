namespace EducationSys.Application.DTOs.Mark
{
    public class CreateMarkDto
    {

        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public double ExamMark { get; set; }
        public double AssignmentMark { get; set; }
    }
}
