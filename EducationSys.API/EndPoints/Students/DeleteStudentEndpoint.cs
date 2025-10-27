using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Interfaces;
using FastEndpoints;

namespace EducationSys.API.EndPoints.Students
{
    public class DeleteStudentEndpoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly IStudentService _studentService;

        public DeleteStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Delete("/students/{id:int}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<int>("id"); // Read from route parameter
            var result = _studentService.DeleteStudentAsync(id);
            await Send.OkAsync(result, ct);
        }
    }
}
