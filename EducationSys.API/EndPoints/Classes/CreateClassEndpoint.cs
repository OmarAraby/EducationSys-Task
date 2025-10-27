using EducationSys.Application.DTOs.Class;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Interfaces;
using EducationSys.Application.Validators.Class;
using FastEndpoints;

namespace EducationSys.API.EndPoints.Classes
{
    public class CreateClassEndpoint : Endpoint<CreateClassDto,ApiResponse<ClassDto>>
    {
        private readonly IClassService _classService;

        public CreateClassEndpoint(IClassService classService)
        {
            _classService = classService;
        }

        public override void Configure()
        {
            Post("/classes");
            AllowAnonymous();
            Validator<CreateClassDtoValidator>();

        }

        public override async Task HandleAsync(CreateClassDto req,CancellationToken ct)
        {
            var result = _classService.CreateClassAsync(req);

            await Send.OkAsync(result,cancellation:ct);
        }

    }
}
