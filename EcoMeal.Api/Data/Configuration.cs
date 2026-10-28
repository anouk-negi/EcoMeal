using EcoMeal.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;

namespace EcoMeal.Api.Data
{
    public class BusinessConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasKey(b => b.ID);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(b => b.Description);

            builder.Property(b => b.Address)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(b => b.ImageURL)
                .HasMaxLength(255);

            builder.HasOne(b => b.Type)
                .WithMany(b => b.Businesses)
                .HasForeignKey(b => b.BusinessTypeID);

            builder.HasOne(b => b.Owner)
            .WithMany()
            .HasForeignKey(b => b.OwnerID)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }

    public class BusinessTypeConfiguration : IEntityTypeConfiguration<BusinessType>
    {
        public void Configure(EntityTypeBuilder<BusinessType> builder)
        {
            builder.HasKey(t => t.ID);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.ID);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Business)
                .WithMany(b => b.Orders)
                .HasForeignKey(o => o.BusinessID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Status)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StatusID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(o => o.OrderNumber)
                .IsRequired();
        }
    }

    public class OrderPackageConfiguration : IEntityTypeConfiguration<OrderPackage>
    {
        public void Configure(EntityTypeBuilder<OrderPackage> builder)
        {
            builder.HasKey(p => new { p.OrderID, p.PackageID });

            builder.HasOne(o => o.Order)
                .WithMany(o => o.Packages)
                .HasForeignKey(o => o.OrderID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Package)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.PackageID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(o => o.Quantitiy);
        }
    }

    public class PackageConfiguration: IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.HasKey(p => p.ID);

            builder.HasOne(p => p.Business)
                .WithMany(b => b.Packages)
                .HasForeignKey(p => p.BusinessID);

            builder.HasOne(p => p.Type)
               .WithMany(b => b.Packages)
               .HasForeignKey(p => p.PackageTypeID);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Description);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.AvailableQuantitity)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(p => p.PickupStart)
                .IsRequired();

            builder.Property(p => p.PickupEnd)
                .IsRequired();

            builder.Property(p => p.ImageURL)
                .HasMaxLength(255);
        }
    }

    public class PackageTypeConfiguration : IEntityTypeConfiguration<PackageType>
    {
        public void Configure(EntityTypeBuilder<PackageType> builder)
        {
            builder.HasKey(t => t.ID);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }

    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.ToTable("AspNetRoles");
        }
    }

    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.ID);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.ID);

            builder.Property(p => p.Email)
               .IsRequired()
               .HasMaxLength(255);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
