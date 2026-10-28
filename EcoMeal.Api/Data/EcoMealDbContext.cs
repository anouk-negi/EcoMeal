using EcoMeal.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.Api.Data
{
    public class EcoMealDbContext : DbContext
    {
        public EcoMealDbContext(DbContextOptions<EcoMealDbContext> options)
            : base(options) { }

        public DbSet<Business> Businesses => Set<Business>();
        public DbSet<BusinessType> BusinessTypes => Set<BusinessType>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderPackage> OrderPackages => Set<OrderPackage>();
        public DbSet<Package> Packages => Set<Package>();
        public DbSet<PackageType> PackageType => Set<PackageType>();
        public DbSet<Role> Role => Set<Role>();
        public DbSet<Status> Status => Set<Status>();
        public DbSet<User> User => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BusinessConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderPackageConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConfiguration());
            modelBuilder.ApplyConfiguration(new PackageTypeConfiguration()); 
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
