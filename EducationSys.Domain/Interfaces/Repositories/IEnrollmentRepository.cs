using EducationSys.Domain.Entities;

namespace EducationSys.Domain.Interfaces.Repositories
{
    public interface IEnrollmentRepository
    {
        bool EnrollStudent(int studentId, int classId);

        bool Unenroll(int id);

        bool Exists(int id);
        bool IsEnrolled(int studentId, int classId);
        IReadOnlyList<Enrollment> GetAll();

        Enrollment? GetById(int id);

        IReadOnlyList<Enrollment> GetByStudentId(int studentId);

        IReadOnlyList<Enrollment> GetByClassId(int classId);

        Enrollment? GetByStudentAndClass(int studentId, int classId);

    }
}
