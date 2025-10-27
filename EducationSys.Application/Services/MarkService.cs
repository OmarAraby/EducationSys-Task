using EducationSys.Application.DTOs.Mark;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Interfaces;
using EducationSys.Domain.Entities;
using EducationSys.Domain.Interfaces.Repositories;

namespace EducationSys.Application.Services
{
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository _markRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public MarkService(IMarkRepository markRepository, IStudentRepository studentRepository, IClassRepository classRepository, IEnrollmentRepository enrollmentRepository)
        {
            _markRepository = markRepository;
            _studentRepository = studentRepository;
            _classRepository = classRepository;
            _enrollmentRepository = enrollmentRepository;

        }
        public ApiResponse<double> CalculateAverageForClass(int classId)
        {
            // Check existence of class
            if (!_classRepository.Exists(classId))
            {
                return ApiResponse<double>.ErrorResponse($"Class with this {classId} doesn't exist");
            }

            var classMark = _markRepository.GetByClassId(classId);
            if (classMark == null || classMark.Count == 0)
                return ApiResponse<double>.ErrorResponse("No marks found ");

            var average = (double)classMark.Average(m => m.TotalMark);
            return ApiResponse<double>.SuccessResponse(average, "Average calculated successfully");


        }

        public ApiResponse<MarkDto> RecordMark(CreateMarkDto createMarkDto)
        {
            var studentId = createMarkDto.StudentId;
            var classId = createMarkDto.ClassId;
            var examMark = createMarkDto.ExamMark;
            var assignmentMark = createMarkDto.AssignmentMark;

            if (!_studentRepository.Exists(studentId))
                return ApiResponse<MarkDto>.ErrorResponse($"Student with ID {studentId} not found.");

            if (!_classRepository.Exists(classId))
                return ApiResponse<MarkDto>.ErrorResponse($"Class with ID {classId} not found.");

            if (!_enrollmentRepository.IsEnrolled(studentId, classId))
                return ApiResponse<MarkDto>.ErrorResponse("Student is not enrolled in this class.");

            if (_markRepository.GetByStudentAndClass(studentId, classId) != null)
                return ApiResponse<MarkDto>.ErrorResponse("Marks for this student and class already exist.");

            var newId = _markRepository.GetAll().Any() ? _markRepository.GetAll().Max(m => m.Id) + 1 : 1;

            var mark = new Mark
            {
                Id = newId,
                StudentId = studentId,
                ClassId = classId,
                ExamMark = (decimal)examMark,
                AssignmentMark = (decimal)assignmentMark
            };

            var added = _markRepository.AddMark(mark);
            if (!added)
                return ApiResponse<MarkDto>.ErrorResponse("Failed to record mark.");

            var Markdto = new MarkDto
            {
                Id = mark.Id,
                StudentId = mark.StudentId,
                ClassId = mark.ClassId,
                ExamMark = (double)mark.ExamMark,
                AssignmentMark = (double)mark.AssignmentMark
            };

            return ApiResponse<MarkDto>.SuccessResponse(Markdto, "Mark recorded successfully.");
        }
    }
}

