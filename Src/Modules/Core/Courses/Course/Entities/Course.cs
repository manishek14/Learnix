using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Course.Data.Entities
{
    public class Course : BaseEntity
    {
        [MaxLength(200)]
        public string Title { get; private set; }
        [MaxLength(200)]
        public string Slug { get; private set; }
        public string Description { get; private set; }
        public string ImageName { get; private set; }
        public Guid InstructorId { get; private set; }
        public int Price { get; private set; }
        public bool IsPublished { get; private set; }
        public Guid CategoryId { get; private set; }

        public CourseCategory Category { get; private set; }
        public List<CourseSection> Sections { get; private set; }

        protected Course() { }

        public Course(string title, string slug, string description, string imageName, Guid instructorId, int price, Guid categoryId)
        {
            Guard(title, slug, description, imageName, instructorId, price, categoryId);

            Title = title;
            Slug = slug;
            Description = description;
            ImageName = imageName;
            InstructorId = instructorId;
            Price = price;
            CategoryId = categoryId;
            IsPublished = false; 
            Sections = new List<CourseSection>();
        }

        public void Edit(string title, string slug, string description, string imageName, int price, Guid categoryId)
        {
            Guard(title, slug, description, imageName, InstructorId, price, categoryId);

            Title = title;
            Slug = slug;
            Description = description;
            ImageName = imageName;
            Price = price;
            CategoryId = categoryId;
        }

        public void Publish() => IsPublished = true;
        public void Unpublish() => IsPublished = false;

        public void AddSection(CourseSection section)
        {
            if (section == null) throw new ArgumentNullException(nameof(section));
            Sections.Add(section);
        }
        public void RemoveSection(CourseSection section)
        {
            if (section == null) throw new ArgumentNullException(nameof(section));

            if (section.CourseId != Id)
                throw new InvalidDomainDataException("This section does not belong to this course");

            Sections.Remove(section);
        }

        private void Guard(string title, string slug, string description, string imageName, Guid instructorId, int price, Guid categoryId)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(Title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(Slug));
            NullOrEmptyDomainDataException.CheckString(description, nameof(Description));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(ImageName));

            if (instructorId == Guid.Empty) throw new NullOrEmptyDomainDataException("InstructorId is empty");
            if (categoryId == Guid.Empty) throw new NullOrEmptyDomainDataException("CategoryId is empty");
            if (price < 0) throw new InvalidDomainDataException("Price cannot be negative");
        }
    }
}