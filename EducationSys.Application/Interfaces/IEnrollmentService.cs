using EducationSys.Application.Helpers.GeneralResult;

namespace EducationSys.Application.Interfaces
{
    public interface IEnrollmentService
    {
        ApiResponse EnrollStudent(int studentId, int classId);

    }
}
