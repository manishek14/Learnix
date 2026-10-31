using Microsoft.EntityFrameworkCore;
using Course.Entities;

namespace Course.Context
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }

        public DbSet<CourseCategory> Categories { get; set; }
        public DbSet<Entities.Course> Courses { get; set; }
        public DbSet<CourseSection> Sections { get; set; }
        public DbSet<CourseEpisode> Episodes { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entities.Course>()
                .HasMany(c => c.Sections)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourseSection>()
                .HasMany(s => s.Episodes)
                .WithOne(e => e.Section)
                .HasForeignKey(e => e.SectionId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Entities.Course>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<UserCourse>()
                .HasOne(uc => uc.Course)
                .WithMany()
                .HasForeignKey(uc => uc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourseCategory>().ToTable("Categories", "Course");
            modelBuilder.Entity<Entities.Course>().ToTable("Courses", "Course");
            modelBuilder.Entity<CourseSection>().ToTable("Sections", "Course");
            modelBuilder.Entity<CourseEpisode>().ToTable("Episodes", "Course");
            modelBuilder.Entity<UserCourse>().ToTable("UserCourses", "Course");
        }
    }
}