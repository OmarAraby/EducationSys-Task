using EducationSys.Domain.Entities;
using EducationSys.Domain.Interfaces.Repositories;
using System.Collections.Concurrent;

namespace EducationSys.Infrastructure.Repositories.InMemory
{
    internal class MarkRepository:IMarkRepository
    {
        private readonly ConcurrentDictionary<int, Mark> _marks = new();

        public bool AddMark(Mark mark)
        {
            if (mark == null || _marks.ContainsKey(mark.Id))
                return false;

            return _marks.TryAdd(mark.Id, mark);
        }

        public bool Delete(int id)
        {
            return _marks.TryRemove(id, out _);
        }

        public bool Exists(int id)
        {
            return _marks.ContainsKey(id);
        }

        public IReadOnlyList<Mark> GetAll()
        {
            return _marks.Values.ToList();
        }

        public Mark? GetById(int id)
        {
            _marks.TryGetValue(id, out var mark);
            return mark;
        }

        public IReadOnlyList<Mark> GetByStudentId(int studentId)
        {
            return _marks.Values.Where(m => m.StudentId == studentId).ToList();
        }

        public IReadOnlyList<Mark> GetByClassId(int classId)
        {
            return _marks.Values.Where(m => m.ClassId == classId).ToList();
        }

        public Mark? GetByStudentAndClass(int studentId, int classId)
        {
            return _marks.Values.FirstOrDefault(m => m.StudentId == studentId && m.ClassId == classId);
        }

    }
}
