using Blog.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Services.DTOs.Query
{
    public class BlogPostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public string Slug { get; set; }
        public string OwnerName { get; set; }
        public string Content { get; set; }
        public long Visit { get; set; }
        public long ImageName { get; set; }
        public DateTime CreationDate { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
