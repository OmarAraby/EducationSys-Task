using EducationSys.Application.DTOs.Student;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Helpers.Pagination;
using EducationSys.Application.Interfaces;
using FastEndpoints;

namespace EducationSys.API.EndPoints.Students
{
    public class GetAllStudentsEndpoint : EndpointWithoutRequest<ApiResponse<PageList<StudentDto>>>
    {
        private readonly IStudentService _studentService;

        public GetAllStudentsEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Get("/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var queryParams = new QueryParams
            {
                PageNumber = Query<int>("pageNumber", 1),
                PageSize = Query<int>("pageSize", 10),
                SearchTerm = Query<string?>("searchTerm", null)
            };

            var result = _studentService.GetAllStudentsAsync(queryParams);
            await SendOkAsync(result, ct);
        }
    }
}
