using Common.Application;
using Course.DTOs;
using System;
using System.Threading.Tasks;

namespace Course.DomainService
{
    public interface ICourseService
    {
        Task<OperationResult<Guid>> CreateCourse(CreateCourseCommand command);
        Task<OperationResult> AddSection(CreateSectionCommand command);
        Task<OperationResult> AddEpisode(CreateEpisodeCommand command);
        Task<OperationResult> PublishCourse(Guid courseId);
        Task<CourseDto> GetCourseById(Guid courseId);
    }
}