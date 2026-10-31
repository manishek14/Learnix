using System;
using System.Collections.Generic;

namespace Course.DTOs
{
    public class CreateCourseCommand
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public Guid InstructorId { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class CreateSectionCommand
    {
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public Guid CourseId { get; set; }
    }

    public class CreateEpisodeCommand
    {
        public string Title { get; set; }
        public string VideoFileName { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsFree { get; set; }
        public int DisplayOrder { get; set; }
        public Guid SectionId { get; set; }
    }

    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public Guid InstructorId { get; set; }
        public int Price { get; set; }
        public bool IsPublished { get; set; }
        public Guid CategoryId { get; set; }
        public List<SectionDto> Sections { get; set; }
    }

    public class SectionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public List<EpisodeDto> Episodes { get; set; }
    }

    public class EpisodeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsFree { get; set; }
        public int DisplayOrder { get; set; }
    }
}