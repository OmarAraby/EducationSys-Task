using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using EducationSys.Application.Interfaces;
using EducationSys.Application.Services;

namespace EducationSys.Application.DependencyInjection
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
        


            // validations
            services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);

            return services;
        }
    }
}
