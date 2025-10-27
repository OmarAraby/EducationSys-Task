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
            services.AddScoped<IClassService, ClassService>();




            // validations
            services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);

            return services;
        }
    }
}
