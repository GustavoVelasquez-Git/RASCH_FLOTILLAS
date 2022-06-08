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
        public DbSet<BrandGps> BrandsGps { get; set; }
        public DbSet<Fuels> Fuels { get; set; }
        public DbSet<Hologram> Holograms { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanys { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<TypeMaintenance> TypeMaintenances { get; set; }
        public DbSet<TypesVehicle> TypesVehicles { get; set; }
        public DbSet<VehicleStatus> VehicleStatus { get; set; }
        public DbSet<Workshop> WorkShops { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Business>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Brands>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<BrandGps>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Fuels>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Hologram>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<InsuranceCompany>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Key>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Owner>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<PaymentMethod>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Service>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<State>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<TypeMaintenance>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<TypesVehicle>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<VehicleStatus>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Workshop>().HasIndex(x => x.Description).IsUnique();

        }
    }
}