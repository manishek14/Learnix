using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Domain
{
    [Index("Slug")]
    public class Category : BaseEntity
    {
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(80)]
        public string Slug { get; set; }
    }
}
