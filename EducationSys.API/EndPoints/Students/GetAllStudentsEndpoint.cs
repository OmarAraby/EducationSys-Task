using EducationSys.Application.DTOs.Student;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Helpers.Pagination;
using EducationSys.Application.Interfaces;
using FastEndpoints;

namespace EducationSys.API.EndPoints.Students
{
    public class GetAllStudentsEndpoint : Endpoint<QueryParams, ApiResponse<PageList<StudentDto>>>
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

        public override async Task HandleAsync(QueryParams req, CancellationToken ct) { 
         
            var result =  _studentService.GetAllStudentsAsync(req); 

            await Send.OkAsync(result, cancellation: ct); 
        }
    }
}