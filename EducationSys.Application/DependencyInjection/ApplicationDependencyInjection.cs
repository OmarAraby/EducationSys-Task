using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using EducationSys.Application.Interfaces;
using EducationSys.Application.Services;
using System.Runtime.Intrinsics.X86;

namespace EducationSys.Application.DependencyInjection
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<IMarkService, MarkService>();




            // validations
            services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);

            return services;
        }
    }
}
