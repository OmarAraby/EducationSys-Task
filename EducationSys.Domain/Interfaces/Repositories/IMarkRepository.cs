using EducationSys.Domain.Entities;

namespace EducationSys.Domain.Interfaces.Repositories
{
    public interface IMarkRepository
    {
        bool AddMark(Mark mark);

        bool Delete(int id);

        bool Exists(int id);

        IReadOnlyList<Mark> GetAll();

        Mark? GetById(int id);

        IReadOnlyList<Mark> GetByStudentId(int studentId);

        IReadOnlyList<Mark> GetByClassId(int classId);

        Mark? GetByStudentAndClass(int studentId, int classId);

    }
}
