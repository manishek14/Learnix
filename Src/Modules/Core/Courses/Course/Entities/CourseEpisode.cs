using Common.Domain;
using Common.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Course.Entities
{
    public class CourseEpisode : BaseEntity
    {
        [MaxLength(200)]
        public string Title { get; private set; }
        public string VideoFileName { get; private set; }
        public TimeSpan Duration { get; private set; }
        public bool IsFree { get; private set; }
        public int DisplayOrder { get; private set; }
        public Guid SectionId { get; private set; }

        public CourseSection Section { get; private set; }

        protected CourseEpisode() { }

        public CourseEpisode(string title, string videoFileName, TimeSpan duration, bool isFree, int displayOrder, Guid sectionId)
        {
            Guard(title, videoFileName, duration, sectionId);
            Title = title;
            VideoFileName = videoFileName;
            Duration = duration;
            IsFree = isFree;
            DisplayOrder = displayOrder;
            SectionId = sectionId;
        }

        public void Edit(string title, string videoFileName, TimeSpan duration, bool isFree, int displayOrder)
        {
            Guard(title, videoFileName, duration, SectionId);
            Title = title;
            VideoFileName = videoFileName;
            Duration = duration;
            IsFree = isFree;
            DisplayOrder = displayOrder;
        }

        private void Guard(string title, string videoFileName, TimeSpan duration, Guid sectionId)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(Title));
            NullOrEmptyDomainDataException.CheckString(videoFileName, nameof(VideoFileName));

            if (sectionId == Guid.Empty) throw new NullOrEmptyDomainDataException("SectionId is empty");
            if (duration.TotalMinutes <= 0) throw new InvalidDomainDataException("Duration must be greater than zero");
        }
    }
}