using AngleSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserModules.Core.Repositories;
using UserModules.Core.Services;
using UserModules.Data;

namespace UserModules.Core
{
    public static class UserBootstrapper
    {
        public static IServiceCollection InitUserModule(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration config)
        {
            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(config.GetConnectionString("User_Connection"))
            );

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(cfg => { }, typeof(UserMappingProfile).Assembly);

            return services;
        }
    }
}