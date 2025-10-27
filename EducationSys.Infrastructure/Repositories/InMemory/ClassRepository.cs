using EducationSys.Domain.Entities;
using EducationSys.Domain.Interfaces.Repositories;
using System.Collections.Concurrent;

namespace EducationSys.Infrastructure.Repositories.InMemory
{
    public class ClassRepository : IClassRepository
    {
        private readonly ConcurrentDictionary<int, Class> _class = new();

        public bool AddClass(Class __class)
        {
            return _class.TryAdd(__class.Id, __class);
        }

        public bool Delete(int id)
        {
            return _class.TryRemove(id,out _);
        }

        public bool Exists(int id)
        {
            return _class.ContainsKey(id);
        }

        public IReadOnlyList<Class> GetAll()
        {
            return _class.Values.ToList();

        }

        public Class? GetById(int id)
        {
            _class.TryGetValue(id, out var __class);
            return __class;
        }

        public bool Update(Class __class)
        {
            if (_class.ContainsKey(__class.Id))
            {
                _class[__class.Id] = __class;

                return true;
            }
            return false;
        }
    }
}
