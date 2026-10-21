using Blog.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog
{
    public static class BlogBootstrapper
    {
        public static IServiceCollection InitBlogModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<BlogConext>(options => 
            options.UseSqlServer(config.GetConnectionString("Blog_Connection"))
            );
            return services;
        }
    }
}
