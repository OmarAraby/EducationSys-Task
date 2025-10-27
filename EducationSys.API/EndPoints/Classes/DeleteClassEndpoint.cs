using EducationSys.Application.Helpers.GeneralResult;
using EducationSys.Application.Interfaces;
using FastEndpoints;

namespace EducationSys.API.EndPoints.Classes
{
    public class DeleteClassEndpoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly IClassService _classService;

        public DeleteClassEndpoint(IClassService classService)
        {
            _classService = classService;
        }

        public override void Configure()
        {
            Delete("/classes/{id:int}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<int>("id"); // Read from route parameter
            var result = _classService.DeleteClassAsync(id);
            await Send.OkAsync(result, ct);
        }
    }
    
}
