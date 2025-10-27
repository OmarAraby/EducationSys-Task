using EducationSys.Domain.Entities;
using EducationSys.Domain.Interfaces.Repositories;
using System.Collections.Concurrent;

namespace EducationSys.Infrastructure.Repositories.InMemory
{
    public class EnrollmentRepository: IEnrollmentRepository
    {
        private readonly ConcurrentDictionary<int, Enrollment> _enrollments = new();

        public bool EnrollStudent(int studentId, int classId)
        {
          
            var maxId = _enrollments.Any() ? _enrollments.Values.Max(e => e.Id) : 0;
            var newId = maxId + 1;

       
            if (IsEnrolled(studentId, classId))
                return false; 

            var enrollment = new Enrollment
            {
                Id = newId,
                StudentId = studentId,
                ClassId = classId,
            };

            return _enrollments.TryAdd(newId, enrollment);
        }

        public bool Unenroll(int id)
        {
            return _enrollments.TryRemove(id, out _);
        }

        public bool Exists(int id)
        {
            return _enrollments.ContainsKey(id);
        }

        public bool IsEnrolled(int studentId, int classId)
        {
            return _enrollments.Values.Any(e => e.StudentId == studentId && e.ClassId == classId);
        }

        public IReadOnlyList<Enrollment> GetAll()
        {
            return _enrollments.Values.ToList();
        }

        public Enrollment? GetById(int id)
        {
            _enrollments.TryGetValue(id, out var enrollment);
            return enrollment;
        }

        public IReadOnlyList<Enrollment> GetByStudentId(int studentId)
        {
            return _enrollments.Values.Where(e => e.StudentId == studentId).ToList();
        }

        public IReadOnlyList<Enrollment> GetByClassId(int classId)
        {
            return _enrollments.Values.Where(e => e.ClassId == classId).ToList();
        }

        public Enrollment? GetByStudentAndClass(int studentId, int classId)
        {
            return _enrollments.Values.FirstOrDefault(e => e.StudentId == studentId && e.ClassId == classId);
        }
    }

}

