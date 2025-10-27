using EducationSys.API.EndPoints.Students.RequestsDtos;
using EducationSys.Application.DTOs.Student;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Interfaces;
using FastEndpoints;

namespace EducationSys.API.EndPoints.Students
{
    public class UpdateStudentEndpoint : Endpoint<UpdateStudentRequest, ApiResponse<StudentDto>>
    {
        private readonly IStudentService _studentService;

        public UpdateStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Put("/students/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateStudentRequest req, CancellationToken ct)
        {
            var result = _studentService.UpdateStudentAsync(req.Id, new UpdateStudentDto
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Age = req.Age
            });


         

            await Send.OkAsync(result, ct);
        }
    }
}
