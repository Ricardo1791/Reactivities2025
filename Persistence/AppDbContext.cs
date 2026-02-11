using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class AppDbContext(DbContextOptions options): IdentityDbContext<User>(options)
    {
        public required DbSet<Activity> Activities { get; set; }
        public required DbSet<ActivityAtendee> ActivityAtendees { get; set; }
        public required DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ActivityAtendee>(x => x.HasKey(a => new { a.ActivityId, a.UserId }));

            builder.Entity<ActivityAtendee>().HasOne(x => x.User).WithMany(x => x.Activities)
                .HasForeignKey(x => x.UserId);

            builder.Entity<ActivityAtendee>().HasOne(x => x.Activity).WithMany(x => x.Atendees)
                .HasForeignKey(x => x.ActivityId);

        }
    }
}
