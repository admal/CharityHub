using CharityHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Domain
{
    public class CharityHubContext : DbContext
    {
        public CharityHubContext(DbContextOptions<CharityHubContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
