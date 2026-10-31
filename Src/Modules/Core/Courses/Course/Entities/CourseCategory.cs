using Common.Domain;
using Common.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Course.Entities
{
    public class CourseCategory : BaseEntity
    {
        [MaxLength(100)]
        public string Title { get; private set; }
        [MaxLength(100)]
        public string Slug { get; private set; }
        public List<Course> Courses { get; private set; }

        protected CourseCategory() { }

        public CourseCategory(string title, string slug)
        {
            Guard(title, slug);
            Title = title;
            Slug = slug;
        }

        public void Edit(string title, string slug)
        {
            Guard(title, slug);
            Title = title;
            Slug = slug;
        }

        private void Guard(string title, string slug)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(Title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(Slug));
        }
    }
}