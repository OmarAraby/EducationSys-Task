using EducationSys.Domain.Entities;
using EducationSys.Domain.Interfaces.Repositories;
using System.Collections.Concurrent;

namespace EducationSys.Infrastructure.Repositories.InMemory
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ConcurrentDictionary<int, Student> _students = new();

        public bool Addstudent(Student student)
        {
            return _students.TryAdd(student.Id, student);
        }

        public bool Delete(int id)
        {
            return _students.TryRemove(id, out _);
        }

        public bool Exists(int id)
        {
            return _students.ContainsKey(id);
        }

        public IReadOnlyList<Student> GetAll()
        {
            return _students.Values.ToList();
        }

        public Student? GetById(int id)
        {
            _students.TryGetValue(id, out var student);
            return student;
        }

        public bool Update(Student student)
        {
            if (_students.ContainsKey(student.Id))
            {
                _students[student.Id] = student;
                return true;
            }
            return false;
        }
    }
}
