using Common.Domain.Repository;
using Course.Entities;

namespace Course.Repositories
{
    public interface ICourseRepository : IBaseRepository<Entities.Course> { }
    public interface ICategoryRepository : IBaseRepository<CourseCategory> { }
    public interface ISectionRepository : IBaseRepository<CourseSection> { }
    public interface IEpisodeRepository : IBaseRepository<CourseEpisode> { }
    public interface IUserCourseRepository : IBaseRepository<UserCourse> { }
}