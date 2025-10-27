using EducationSys.Domain.Entities;

namespace EducationSys.Domain.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        bool Addstudent(Student student);
        Student? GetById(int id);
        IReadOnlyList<Student> GetAll();
        bool Update(Student student);
        bool Delete(int id);
        bool Exists(int id);
    }
}
