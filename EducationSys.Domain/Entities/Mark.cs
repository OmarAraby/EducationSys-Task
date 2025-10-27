namespace EducationSys.Domain.Entities
{
    public class Mark
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public decimal ExamMark { get; set; }
        public decimal AssignmentMark { get; set; }

        // toyal mark
        public decimal TotalMark => ExamMark + AssignmentMark;
    }
}
