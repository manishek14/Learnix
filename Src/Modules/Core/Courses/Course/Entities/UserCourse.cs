using Common.Domain;
using Common.Domain.Exceptions;

namespace Course.Entities
{
    public class UserCourse : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid CourseId { get; private set; }

        public Course Course { get; private set; }

        protected UserCourse() { }

        public UserCourse(Guid userId, Guid courseId)
        {
            if (userId == Guid.Empty) throw new NullOrEmptyDomainDataException("UserId is empty");
            if (courseId == Guid.Empty) throw new NullOrEmptyDomainDataException("CourseId is empty");

            UserId = userId;
            CourseId = courseId;
        }
    }
}