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

        public override async Task HandleAsync(CancellationToken ct) {
            var queryParams = new QueryParams
            {
                SearchTerm = Query<string?>("SearchTerm", isRequired: false),
                PageNumber = Query<int>("PageNumber", isRequired: false),
                PageSize = Query<int>("PageSize", isRequired: false)
            };

            if (queryParams.PageNumber <= 0) queryParams.PageNumber = 1;
            if (queryParams.PageSize <= 0) queryParams.PageSize = 10;

            var result =  _studentService.GetAllStudentsAsync(queryParams); 

            await Send.OkAsync(result, cancellation: ct); 
        }
    }
}