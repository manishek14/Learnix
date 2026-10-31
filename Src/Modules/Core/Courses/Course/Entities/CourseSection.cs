using Common.Domain;
using Common.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Course.Data.Entities
{
    public class CourseSection : BaseEntity
    {
        [MaxLength(200)]
        public string Title { get; private set; }
        public int DisplayOrder { get; private set; }
        public Guid CourseId { get; private set; }

        public Course Course { get; private set; }
        public List<CourseEpisode> Episodes { get; private set; }

        protected CourseSection() { }

        public CourseSection(string title, int displayOrder, Guid courseId)
        {
            Guard(title, courseId);
            Title = title;
            DisplayOrder = displayOrder;
            CourseId = courseId;
            Episodes = new List<CourseEpisode>();
        }

        public void Edit(string title, int displayOrder)
        {
            Guard(title, CourseId);
            Title = title;
            DisplayOrder = displayOrder;
        }

        public void AddEpisode(CourseEpisode episode)
        {
            if (episode == null) throw new ArgumentNullException(nameof(episode));
            Episodes.Add(episode);
        }

        public void RemoveEpisode(CourseEpisode episode)
        {
            if (episode == null) throw new ArgumentNullException(nameof(episode));

            if (episode.SectionId != Id)
                throw new InvalidDomainDataException("This episode does not belong to this section");

            Episodes.Remove(episode);
        }

        private void Guard(string title, Guid courseId)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(Title));
            if (courseId == Guid.Empty) throw new NullOrEmptyDomainDataException("CourseId is empty");
        }
    }
}