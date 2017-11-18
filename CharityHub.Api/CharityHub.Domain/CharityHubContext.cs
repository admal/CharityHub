using CharityHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharityHub.Domain
{
    public class CharityHubContext : DbContext
    {
        public CharityHubContext(DbContextOptions<CharityHubContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Charity> Charities { get; set; }
        public DbSet<CharityEvent> CharityEvents { get; set; }
        public DbSet<EventNotification> EventNotifications { get; set; }

        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<User_Charity> Users_Charities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //HACK!
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //koniec HACKA!

            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<Charity>()
                .ToTable("Charities");

            modelBuilder.Entity<CharityEvent>().ToTable("CharityEvents");
            modelBuilder.Entity<EventNotification>().ToTable("EventNotifications");
            modelBuilder.Entity<EventParticipant>().ToTable("EventParticipants");
            modelBuilder.Entity<User_Charity>().ToTable("Users_Charities");
        }
    }
}
