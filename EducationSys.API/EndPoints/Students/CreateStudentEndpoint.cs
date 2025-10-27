using EducationSys.Application.DTOs.Student;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Interfaces;
using EducationSys.Application.Validators.Student;
using FastEndpoints;
using System.Net;

namespace EducationSys.API.EndPoints.Students
{
    public class CreateStudentEndpoint : Endpoint<CreateStudentDto, ApiResponse<StudentDto>>
    {
        private readonly IStudentService _studentService;

        public CreateStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public override void Configure()
        {
            Post("/students");
            AllowAnonymous();
            Validator<CreateStudentDtoValidator>(); 

        }


        public override async  Task HandleAsync(CreateStudentDto req, CancellationToken ct)
        {
          
            var result =  _studentService.CreateStudentAsync(req);


            await Send.OkAsync(result, cancellation: ct);
        }

    }
}
