using Blog.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Services.DTOs.Command
{
    public class CreatePostCommand
    {
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public string Slug { get; set; }
        public string OwnerName { get; set; }
        public string Content { get; set; }
        public IFormFile ImageFile { get; set; }
        public DateTime CreationDate { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
    public class EditPostCommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public string Slug { get; set; }
        public string OwnerName { get; set; }
        public string Content { get; set; }
        public IFormFile ImageFile { get; set; }
        public DateTime CreationDate { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
