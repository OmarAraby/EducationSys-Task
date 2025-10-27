using EducationSys.Application.DTOs.Class;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Helpers.Pagination;
using EducationSys.Application.Interfaces;
using FastEndpoints;

namespace EducationSys.API.EndPoints.Classes
{
    public class GetAllClassesEndPoint:Endpoint<QueryParams,ApiResponse<PageList<ClassDto>>>
    {
        private readonly IClassService _classService;

        public GetAllClassesEndPoint(IClassService classService)
        {
            _classService = classService;
        }

        public override void Configure()
        {
            Get("/classes");
            AllowAnonymous();

        }
        public override async Task HandleAsync(QueryParams req, CancellationToken ct)
        {

            var result = _classService.GetAllClassesAsync(req);

            await Send.OkAsync(result, cancellation: ct);
        }
    }
}
