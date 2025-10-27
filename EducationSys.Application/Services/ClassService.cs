using EducationSys.Application.DTOs.Class;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Helpers.Pagination;
using EducationSys.Application.Interfaces;
using EducationSys.Domain.Entities;
using EducationSys.Domain.Interfaces.Repositories;

namespace EducationSys.Application.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public ApiResponse<ClassDto> CreateClassAsync(CreateClassDto createClassDto)
        {
            //throw new NotImplementedException();/
            var maxId = _classRepository.GetAll().Any() ? _classRepository.GetAll().Max(c => c.Id) : 0;
            var newClass = new Class
            {
                Id = maxId + 1,
                Name = createClassDto.Name,
                Teacher = createClassDto.Teacher,
                Description = createClassDto.Description
            };

            var added = _classRepository.AddClass(newClass);
            if (!added)
            {
                return ApiResponse<ClassDto>.ErrorResponse("Failed to create class. ID might already exist.");
            }

            var classDto = new ClassDto
            {
                Id = newClass.Id,
                Name = newClass.Name,
                Teacher = newClass.Teacher,
                Description = newClass.Description
            };

            return ApiResponse<ClassDto>.SuccessResponse(classDto, "Class created successfully.");

        }

        public ApiResponse DeleteClassAsync(int id)
        {
            if (!_classRepository.Exists(id))
            {
                return ApiResponse.ErrorResponse($"Class with ID {id} does not exist.");
            }

            var deleted = _classRepository.Delete(id);
            if (!deleted)
            {
                return ApiResponse.ErrorResponse("Failed to delete class.");
            }

            return ApiResponse.SuccessResponse("Class deleted successfully.");
        }

        public async Task<ApiResponse<PageList<ClassDto>>> GetAllClassesAsync(QueryParams queryParams) 
        {
            var allClasses = _classRepository.GetAll();

            if (!string.IsNullOrEmpty(queryParams.SearchTerm))
            {
                var searchTermLower = queryParams.SearchTerm.ToLower();
                allClasses = allClasses.Where(c =>
                    c.Name.ToLower().Contains(searchTermLower) ||
                    c.Teacher.ToLower().Contains(searchTermLower)
                ).ToList();
            }

            var classDtos = allClasses.Select(c => new ClassDto
            {
                Id = c.Id,
                Name = c.Name,
                Teacher = c.Teacher,
                Description = c.Description
            }).ToList();

            var totalCount = classDtos.Count;
            var pagedItems = classDtos.Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                                    .Take(queryParams.PageSize)
                                    .ToList();

            var pageList = new PageList<ClassDto>(pagedItems, totalCount, queryParams.PageNumber, queryParams.PageSize);

            return ApiResponse<PageList<ClassDto>>.SuccessResponse(pageList, "Classes retrieved successfully.");
        }

        public ApiResponse<ClassDto> GetClassByIdAsync(int id)
        {
            var classEntity = _classRepository.GetById(id);
            if (classEntity == null)
            {
                return ApiResponse<ClassDto>.ErrorResponse($"Class with ID {id} does not exist.");
            }

            var classDto = new ClassDto
            {
                Id = classEntity.Id,
                Name = classEntity.Name,
                Teacher = classEntity.Teacher,
                Description = classEntity.Description
            };

            return ApiResponse<ClassDto>.SuccessResponse(classDto, "Class retrieved successfully.");
        }

       
    }
}
