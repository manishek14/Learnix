using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain
{
    [Index("Slug")]
    [Table("Posts", Schema = "Blog")]
    public class Post : BaseEntity
    {
        [MaxLength(200)]
        public string Title { get; set; }
        public Guid UserId { get; set; }
        [MaxLength(80)]
        public string Slug { get; set; }
        [MaxLength(80)]
        public string OwnerName { get; set; }
        public string Content { get; set; }
        public long Visit { get; set; }
        [MaxLength(110)]
        public long ImageName { get; set; }   
        public DateTime CreationDate { get; set; } 
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}