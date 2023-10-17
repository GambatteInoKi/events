using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EventsDbContext : DbContext
    {
        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options) { }

        // DbSet for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RSVP> RSVPs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatMessage>(ConfigureChatMessage);
        }
        private void ConfigureChatMessage(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.HasKey(f => new { f.SenderID, f.ReceiverID });

            builder
                .HasOne(e => e.Receiver)
                .WithMany()
                .HasForeignKey(e => e.ReceiverID)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(e => e.Sender)
                .WithMany()
                .HasForeignKey(e => e.SenderID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
