using EducationSys.Application.DTOs.Class;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Helpers.Pagination;

namespace EducationSys.Application.Interfaces
{
    public interface IClassService
    {
        ApiResponse<ClassDto> CreateClassAsync(CreateClassDto createClassDto);
        //ApiResponse<PageList<ClassDto>> GetAllClassesAsync(QueryParams queryParams);
        Task<ApiResponse<PageList<ClassDto>>> GetAllClassesAsync(QueryParams queryParams);
        ApiResponse DeleteClassAsync(int id);
        ApiResponse<ClassDto> GetClassByIdAsync(int id);
    }
}
