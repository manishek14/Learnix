using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Services.DTOs.Command
{
    public class CreateCategoryCommand
    {
        public string Title { get; set; }
        public string Slug { get; set; }
    }
    public class EditCategoryCommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
