using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RASCH_FLOTILLAS.Data.Entities;


namespace RASCH_FLOTILLAS.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Business> Business { get; set; }
        public DbSet<Brands> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Business>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Brands>().HasIndex(x => x.Description).IsUnique();

        }
    }
}