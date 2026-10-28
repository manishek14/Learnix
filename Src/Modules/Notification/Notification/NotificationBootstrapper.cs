using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notifications.Context;
using Notifications.Services;

namespace Notifications
{
    public static class NotificationBootstrapper
    {
        public static IServiceCollection InitNotificationModule(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration config)
        {
            services.AddDbContext<NotificationContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Notification_Connection"))
            );

            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddAutoMapper(cfg => { }, typeof(NotificationMappingProfile).Assembly);

            return services;
        }
    }
}