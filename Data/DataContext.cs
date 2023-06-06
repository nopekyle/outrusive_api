using Microsoft.EntityFrameworkCore;
using outrusive.Models;

namespace outrusive.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }    

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<Reflection> Reflections { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

    }
}
