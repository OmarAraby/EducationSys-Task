using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Interfaces;
using EducationSys.Domain.Interfaces.Repositories;

namespace EducationSys.Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {

        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IStudentRepository _studentRepository;

        public EnrollmentService(IStudentRepository studentRepository, IClassRepository classRepository, IEnrollmentRepository enrollmentRepository)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
            _enrollmentRepository = enrollmentRepository;

        }
        public ApiResponse EnrollStudent(int studentId, int classId)
        {
            //throw new NotImplementedException();
            // ensure syudent exist

            if (!_studentRepository.Exists(studentId))
            {
                return ApiResponse.ErrorResponse($"Student with ID {studentId} does not exist");

            }
            if (!_classRepository.Exists(classId))
            {
                return ApiResponse.ErrorResponse($"class with ID {classId} does not exist");

            }

            // chek if he already enroll it 

            if (_enrollmentRepository.IsEnrolled(studentId, classId))
            {
                return ApiResponse.ErrorResponse("This student is already enrolled in this class");

            }

            var success = _enrollmentRepository.EnrollStudent(studentId, classId);
            if (!success)
                return ApiResponse.ErrorResponse("Failed to enroll the student");

            return ApiResponse.SuccessResponse("Student enrolled successfullyr");
        }
    }
}
