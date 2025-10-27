using EducationSys.Application.DTOs.Enrollment;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Interfaces;
using EducationSys.Application.Validators.Class;
using EducationSys.Application.Validators.Enrollment;
using FastEndpoints;

namespace EducationSys.API.EndPoints.Enrollments
{
    public class CreateEnrollmentEndPoint :Endpoint<CreateEnrollmentDto, ApiResponse>
    {
        private readonly IEnrollmentService _enrollmentService;
        public CreateEnrollmentEndPoint(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        public override void Configure()
        {
            Post("/enrollments");
            AllowAnonymous();
            Validator<CreateEnrollmentDtoValidator>();
        }

        public override async Task HandleAsync(CreateEnrollmentDto req, CancellationToken ct)
        {
            var result = _enrollmentService.EnrollStudent(req.StudentId, req.ClassId);
            await Send.OkAsync(result, ct);
        }
    }
}
