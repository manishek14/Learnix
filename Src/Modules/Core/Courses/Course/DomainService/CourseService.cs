using AutoMapper;
using Common.Application;
using Course.DTOs;
using Course.Entities;
using Course.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Course.DomainService
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;

        public CourseService(
            ICourseRepository courseRepository,
            ISectionRepository sectionRepository,
            IEpisodeRepository episodeRepository,
            IMapper mapper)
        {
            _courseRepository = courseRepository;
            _sectionRepository = sectionRepository;
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<Guid>> CreateCourse(CreateCourseCommand command)
        {
            if (await _courseRepository.ExistsAsync(c => c.Slug == command.Slug))
                return OperationResult<Guid>.Error("این Slug قبلاً استفاده شده است.");

            var course = new Entities.Course(
                command.Title, command.Slug, command.Description,
                command.ImageName, command.InstructorId,
                command.Price, command.CategoryId);

            await _courseRepository.AddAsync(course);
            await _courseRepository.Save();

            return OperationResult<Guid>.Success(course.Id);
        }

        public async Task<OperationResult> AddSection(CreateSectionCommand command)
        {
            var course = await _courseRepository.GetTracking(command.CourseId);
            if (course == null) return OperationResult.Error("دوره یافت نشد.");

            var section = new CourseSection(command.Title, command.DisplayOrder, course.Id);
            course.AddSection(section);

            await _sectionRepository.AddAsync(section);
            await _courseRepository.Save();

            return OperationResult.Success();
        }

        public async Task<OperationResult> AddEpisode(CreateEpisodeCommand command)
        {
            var section = await _sectionRepository.GetTracking(command.SectionId);
            if (section == null) return OperationResult.Error("سکشن یافت نشد.");

            var episode = new CourseEpisode(
                command.Title, command.VideoFileName,
                command.Duration, command.IsFree,
                command.DisplayOrder, section.Id);

            section.AddEpisode(episode);

            await _episodeRepository.AddAsync(episode);
            await _sectionRepository.Save();

            return OperationResult.Success();
        }

        public async Task<OperationResult> PublishCourse(Guid courseId)
        {
            var course = await _courseRepository.GetTracking(courseId);
            if (course == null) return OperationResult.Error("دوره یافت نشد.");

            course.Publish();
            _courseRepository.Update(course);
            await _courseRepository.Save();

            return OperationResult.Success();
        }

        public async Task<CourseDto> GetCourseById(Guid courseId)
        {
            var course = await _courseRepository.GetAllAsync();
            var found = course.FirstOrDefault(c => c.Id == courseId);

            if (found == null) return null;

            return _mapper.Map<CourseDto>(found);
        }
    }
}