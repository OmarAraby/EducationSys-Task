using EducationSys.Application.DTOs.Class;
using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Helpers.Pagination;
using EducationSys.Application.Interfaces;
using EducationSys.Domain.Entities;
using FastEndpoints;
using System;

namespace EducationSys.API.EndPoints.Classes
{
    public class GetAllClassesEndPoint : EndpointWithoutRequest<ApiResponse<PageList<ClassDto>>>
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

        public override async Task HandleAsync(CancellationToken ct)
        {
            var queryParams = new QueryParams
            {
                SearchTerm = Query<string?>("SearchTerm", isRequired: false),
                PageNumber = Query<int>("PageNumber", isRequired: false),
                PageSize = Query<int>("PageSize", isRequired: false)
            };

            if (queryParams.PageNumber <= 0) queryParams.PageNumber = 1;
            if (queryParams.PageSize <= 0) queryParams.PageSize = 10;

            var result = await _classService.GetAllClassesAsync(queryParams);
            await Send.OkAsync(result, ct);
        }
    }
}
