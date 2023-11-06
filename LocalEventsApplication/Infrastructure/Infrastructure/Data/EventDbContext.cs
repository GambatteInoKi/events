using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

// Note to self, any "Restrict" I have to manually delete the foreign key entries before deleting the primary key entry.

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
            modelBuilder.Entity<Feedback>(ConfigureFeedback);
            modelBuilder.Entity<RSVP>(ConfigureRSVP);
        }
        private void ConfigureChatMessage(EntityTypeBuilder<ChatMessage> builder)
        {
            // builder.HasKey(f => new { f.SenderID, f.ReceiverID });
            builder.HasKey(f => new { f.Id });
            builder
                .HasOne(e => e.Receiver)
                .WithMany()
                .HasForeignKey(e => e.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(e => e.Sender)
                .WithMany()
                .HasForeignKey(e => e.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureFeedback(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(f => new { f.Id });

            builder
                .HasOne(e => e.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(e => e.Event)
                .WithMany(u => u.Reviews)
                .HasForeignKey(e => e.EventFeedbackId)
                .OnDelete(DeleteBehavior.NoAction);
        }
        private void ConfigureRSVP(EntityTypeBuilder<RSVP> builder)
        {
            // builder.HasKey(f => new { f.SenderID, f.ReceiverID });
            builder.HasKey(f => new { f.UserId, f.EventId });

            builder
                .HasOne(r => r.User)
                .WithMany(u => u.RSVPs)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(r => r.Event)
                .WithMany(e => e.RSVPs)
                .HasForeignKey(r => r.EventId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
