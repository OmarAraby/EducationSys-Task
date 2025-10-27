using EducationSys.Domain.Interfaces.Repositories;
using EducationSys.Infrastructure.Repositories.InMemory;
using Microsoft.Extensions.DependencyInjection;

namespace EducationSys.Infrastructure.DependencyInjection
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IStudentRepository,StudentRepository >();
            services.AddSingleton<IClassRepository,ClassRepository >();
            services.AddSingleton<IMarkRepository,MarkRepository >();
            services.AddSingleton<IEnrollmentRepository, EnrollmentRepository>();




            return services;
        }
    }
}
