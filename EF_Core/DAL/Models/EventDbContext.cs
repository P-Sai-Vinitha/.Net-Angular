using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class EventDbContext : DbContext
    {
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<EventDetails> Events { get; set; }
        public DbSet<SessionInfo> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseHelper.GetConnectionString());
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasData(new UserInfo { EmailId = "admin@gmail.com", UserName = "John", Password = "admin123", Role = "Admin" });
            modelBuilder.Entity<EventDetails>().ToTable("EventDetails");
            modelBuilder.Entity<SessionInfo>().HasOne<EventDetails>().WithMany().HasForeignKey(s => s.EventId);
            base.OnModelCreating(modelBuilder);
        }
    }
}