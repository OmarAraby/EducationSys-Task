using EducationSys.Application.DTOs.Mark;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Interfaces;
using FastEndpoints;

namespace EducationSys.API.EndPoints.Classes
{
    public class AvgMarkClassEndPoint : EndpointWithoutRequest<ApiResponse<double>>
    {
        private readonly IMarkService _markService;

        public AvgMarkClassEndPoint(IMarkService markService)
        {
            _markService = markService;
        }

        public override void Configure()
        {
            Get("/classes/{classId}/average-marks");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var classId = Route<int>("classId");

            var result = _markService.CalculateAverageForClass(classId);

            await Send.OkAsync(result, ct);
        }
    }
}
