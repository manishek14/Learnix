using Common.Infrastructure.Repository;
using Course.Context;
using Course.Entities;

namespace Course.Repositories
{
    public class CourseRepository : BaseRepository<Entities.Course, CourseContext>, ICourseRepository
    {
        public CourseRepository(CourseContext context) : base(context) { }
    }
    public class CategoryRepository : BaseRepository<CourseCategory, CourseContext>, ICategoryRepository
    {
        public CategoryRepository(CourseContext context) : base(context) { }
    }
    public class SectionRepository : BaseRepository<CourseSection, CourseContext>, ISectionRepository
    {
        public SectionRepository(CourseContext context) : base(context) { }
    }
    public class EpisodeRepository : BaseRepository<CourseEpisode, CourseContext>, IEpisodeRepository
    {
        public EpisodeRepository(CourseContext context) : base(context) { }
    }
    public class UserCourseRepository : BaseRepository<UserCourse, CourseContext>, IUserCourseRepository
    {
        public UserCourseRepository(CourseContext context) : base(context) { }
    }
}