using GraduationTracker.Application.Interfaces;
using GraduationTracker.Application.Services;
using GraduationTracker.Domain.Interfaces;
using GraduationTracker.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GraduationTracker.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application Layer
            services.AddScoped<IGraduationTrackerService, GraduationTrackerService>();

            // Infra.Data Layer
            services.AddScoped<IDiplomaRepository, DiplomaRepository>();
            services.AddScoped<IRequirementRepository, RequirementRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}
