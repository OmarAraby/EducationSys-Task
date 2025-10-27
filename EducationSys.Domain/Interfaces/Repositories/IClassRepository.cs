using EducationSys.Domain.Entities;

namespace EducationSys.Domain.Interfaces.Repositories
{
    public interface IClassRepository
    {
        bool AddClass(Class __class);
        Class?  GetById(int id);
        IReadOnlyList<Class> GetAll();
        bool Update(Class __class);
        bool Delete(int id);
        bool Exists(int id);
    }
}
