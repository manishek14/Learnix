using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Services.DTOs.Query
{
    public class BlogCategoryDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
