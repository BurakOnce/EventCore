using EventCore_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCore_Api.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Events> Events { get; set; }
        public DbSet<EventDetails> EventDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>()
                .HasKey(e => e.EventId); // Events sınıfında birincil anahtar tanımlama

            modelBuilder.Entity<EventDetails>()
                .HasKey(ed => ed.EventDetailId); // EventDetails sınıfında birincil anahtar tanımlama
        }
    }
}
