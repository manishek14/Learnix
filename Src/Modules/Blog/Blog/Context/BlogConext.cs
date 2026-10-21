using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Context
{
    public class BlogConext : DbContext
    {
        public BlogConext(DbContextOptions<BlogConext> options) : base(options)
        {
        }
        public DbSet<Domain.Post> Posts { get; set; }
        public DbSet<Domain.Category> Categories { get; set; }
    }
}
