using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ticket.Core.Services;
using Ticket.Data;

namespace Ticket
{
    public static class TicketBootstrapper
    {
        public static IServiceCollection InitTicketModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<TicketContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Ticket_Connection"))
            );

            services.AddScoped<ITicketService, TicketService>();
            services.AddAutoMapper(cfg => { }, typeof(TicketMappingProfile).Assembly); 

            return services;
        }
    }
}