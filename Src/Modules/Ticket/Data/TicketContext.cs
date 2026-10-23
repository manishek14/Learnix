using Microsoft.EntityFrameworkCore;

namespace Ticket.Data
{
    public class TicketContext : DbContext 
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

        public DbSet<Entity.Ticket> Tickets { get; set; }
        public DbSet<Entity.TicketMessage> TicketMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entity.Ticket>().ToTable("Tickets");
            modelBuilder.Entity<Entity.TicketMessage>().ToTable("TicketMessages");
        }
    }
}