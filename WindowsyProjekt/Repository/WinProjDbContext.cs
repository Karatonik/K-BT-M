using WindowsyProjekt.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace WindowsyProjekt.Repository
{
    public class WinProjDbContext : DbContext
    {
        public WinProjDbContext(DbContextOptions<WinProjDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(entity => entity.Hash)
                .HasDefaultValue(string.Empty);

            modelBuilder.Entity<User>()
                .HasIndex(entity => entity.Hash)
                .IsUnique();

            modelBuilder.Entity<Street>()
                .HasIndex(entity => entity.Id)
                .IsUnique();
        }

        #region DbSets

        public DbSet<User> Users { get; set; }

        public DbSet<Street> Streets { get; set; }

        #endregion
    }
}
