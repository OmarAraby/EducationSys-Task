using EducationSys.Application.DTOs.Student;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Helpers.Pagination;

namespace EducationSys.Application.Interfaces
{
    public interface IStudentService
    {
        ApiResponse<StudentDto> CreateStudentAsync(CreateStudentDto createStudentDto);
        ApiResponse<PageList<StudentDto>> GetAllStudentsAsync(QueryParams queryParams);
        ApiResponse<StudentDto> UpdateStudentAsync(int id, UpdateStudentDto updateStudentDto);
        ApiResponse DeleteStudentAsync(int id);
        ApiResponse<StudentDto> GetStudentByIdAsync(int id);


    }
}
