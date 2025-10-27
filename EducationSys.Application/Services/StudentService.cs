using EducationSys.Application.DTOs.Student;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Helpers.Pagination;
using EducationSys.Application.Interfaces;
using EducationSys.Domain.Entities;
using EducationSys.Domain.Interfaces.Repositories;

namespace EducationSys.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public ApiResponse<StudentDto> CreateStudentAsync(CreateStudentDto createStudentDto)
        {
            var maxId = _studentRepository.GetAll().Any() ? _studentRepository.GetAll().Max(s => s.Id) : 0;
            var newStudent = new Student
            {
                Id = maxId + 1,
                FirstName = createStudentDto.FirstName,
                LastName = createStudentDto.LastName,
                Age = createStudentDto.Age
            };

            var added = _studentRepository.Addstudent(newStudent);
            if (!added)
            {
                return ApiResponse<StudentDto>.ErrorResponse("Failed to create student. ID might already exist.");
            }

            var studentDto = new StudentDto
            {
                Id = newStudent.Id,
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName,
                Age = newStudent.Age
            };

            return ApiResponse<StudentDto>.SuccessResponse(studentDto, "Student created successfully.");


        }

        public ApiResponse DeleteStudentAsync(int id)
        {
            if (!_studentRepository.Exists(id))
            {
                return ApiResponse.ErrorResponse($"Student with ID {id} does not exist.");
            }

            var deleted = _studentRepository.Delete(id);
            if (!deleted)
            {
                
                return ApiResponse.ErrorResponse("Failed to delete student.");
            }

            return ApiResponse.SuccessResponse("Student deleted successfully.");

        }

        public ApiResponse<PageList<StudentDto>> GetAllStudentsAsync(QueryParams queryParams)
        {
            var allStudents = _studentRepository.GetAll();

            if (!string.IsNullOrEmpty(queryParams.SearchTerm))
            {
                var searchTermLower = queryParams.SearchTerm.ToLower();
                allStudents = allStudents.Where(s =>
                    s.FirstName.ToLower().Contains(searchTermLower) ||
                    s.LastName.ToLower().Contains(searchTermLower) ||
                    s.Age.ToString().Contains(queryParams.SearchTerm)
                ).ToList();
            }

            var studentDtos = allStudents.Select(s => new StudentDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Age = s.Age
            }).ToList();

            var totalCount = studentDtos.Count;
            var pagedItems = studentDtos.Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                                      .Take(queryParams.PageSize)
                                      .ToList();

            var pageList = new PageList<StudentDto>(pagedItems, totalCount, queryParams.PageNumber, queryParams.PageSize);

            return ApiResponse<PageList<StudentDto>>.SuccessResponse(pageList, "Students retrieved successfully.");

        }

        public ApiResponse<StudentDto> GetStudentByIdAsync(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
            {
                return ApiResponse<StudentDto>.ErrorResponse($"Student with ID {id} does not exist.");
            }

            var studentDto = new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age
            };

            return ApiResponse<StudentDto>.SuccessResponse(studentDto, "Student retrieved successfully.");

        }

        public ApiResponse<StudentDto> UpdateStudentAsync(int id, UpdateStudentDto updateStudentDto)
        {
            if (!_studentRepository.Exists(id))
            {
                return ApiResponse<StudentDto>.ErrorResponse($"Student with ID {id} does not exist.");
            }

            var updatedStudent = new Student
            {
                Id = id,
                FirstName = updateStudentDto.FirstName,
                LastName = updateStudentDto.LastName,
                Age = updateStudentDto.Age
            };

            var updated = _studentRepository.Update(updatedStudent);
            if (!updated)
            {
               
                return ApiResponse<StudentDto>.ErrorResponse("Failed to update student.");
            }

            var studentDto = new StudentDto
            {
                Id = updatedStudent.Id,
                FirstName = updatedStudent.FirstName,
                LastName = updatedStudent.LastName,
                Age = updatedStudent.Age
            };

            return ApiResponse<StudentDto>.SuccessResponse(studentDto, "Student updated successfully.");

        }
    }
}
