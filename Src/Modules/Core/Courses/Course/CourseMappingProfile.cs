using AutoMapper;
using Course.DTOs;
using Course.Entities;

namespace Course
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Entities.Course, CourseDto>();
            CreateMap<CourseSection, SectionDto>();
            CreateMap<CourseEpisode, EpisodeDto>();
        }
    }
}