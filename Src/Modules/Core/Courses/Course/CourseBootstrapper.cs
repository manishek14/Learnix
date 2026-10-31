using Course.Context;
using Course.DomainService;
using Course.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Course
{
    public static class CourseBootstrapper
    {
        public static IServiceCollection InitCourseModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CourseContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Course_Connection"))
            );

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            services.AddScoped<IUserCourseRepository, UserCourseRepository>();

            services.AddScoped<ICourseService, CourseService>();
            services.AddAutoMapper(cfg => { }, typeof(CourseMappingProfile).Assembly);

            return services;
        }
    }
}