using Microsoft.EntityFrameworkCore;
using Notifications.Domain;
using System.Reflection.Emit;

namespace Notifications.Context
{
    public class NotificationContext : DbContext
    {
        public NotificationContext(DbContextOptions<NotificationContext> options) : base(options) { }

        public DbSet<Domain.Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Notification>().ToTable("Notifications", "Notification");
        }
    }
}