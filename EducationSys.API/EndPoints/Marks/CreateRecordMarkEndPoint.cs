using EducationSys.Application.DTOs.Mark;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Interfaces;
using EducationSys.Application.Validators.Mark;
using FastEndpoints;

namespace EducationSys.API.EndPoints.Marks
{
    public class CreateRecordMarkEndPoint: Endpoint<CreateMarkDto,ApiResponse<MarkDto>>
    {
        private readonly IMarkService _markService;
        public CreateRecordMarkEndPoint(IMarkService markService)
        {
            _markService = markService;
        }

        public override void Configure()
        {
            Post("/marks");
            AllowAnonymous();
            Validator<CreateMarkDtoValidator>();

        }

        public override async Task HandleAsync(CreateMarkDto req, CancellationToken ct)
        {
            var result = _markService.RecordMark(req);
            await Send.OkAsync(result, cancellation: ct);
        }



    }
}
