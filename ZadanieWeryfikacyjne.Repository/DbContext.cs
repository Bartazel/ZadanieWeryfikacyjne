using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZadanieWeryfikacyjne.Repository.Entities;

namespace ZadanieWeryfikacyjne.Repository
{
    public class DbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ItemDb");
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Category>()
                .HasIndex(e => e.Code)
                .IsUnique();
            modelBuilder.Entity<Category>()
                .HasKey(e => e.Id);
        }
    }
}
