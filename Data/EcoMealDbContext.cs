using EcoMeal.Data.Configuration;
using EcoMeal.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.Data
{
    public class EcoMealDbContext : DbContext
    {
        public EcoMealDbContext(DbContextOptions<EcoMealDbContext> options)
            : base(options){ }

        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Status> Statuses => Set<Status>();
        public DbSet<BusinessType> BusinessTypes => Set<BusinessType>();
        public DbSet<PackageType> PackageTypes => Set<PackageType>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Business> Businesses => Set<Business>();
        public DbSet<Package> Packages => Set<Package>();
        public DbSet<OrderPackage> OrderPackages => Set<OrderPackage>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PackageTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConfiguration());
            modelBuilder.ApplyConfiguration(new OrderPackageConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
