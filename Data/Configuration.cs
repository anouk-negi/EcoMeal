using System;
using EcoMeal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EcoMeal.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.ID);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.ID);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

    public class BusinessTypeConfiguration : IEntityTypeConfiguration<BusinessType>
    {
        public void Configure(EntityTypeBuilder<BusinessType> builder)
        {
            builder.HasKey(b => b.ID);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }

    public class PackageTypeConfiguration : IEntityTypeConfiguration<PackageType>
    {
        public void Configure(EntityTypeBuilder<PackageType> builder)
        {
            builder.HasKey(p => p.ID);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.ID);


            builder.Property(p => p.RoleID)
                .IsRequired();

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(p => p.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.RoleID);
        }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.ID);

            builder.HasOne(p => p.User)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.UserID);

            builder.HasOne(p=> p.Business)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.BusinessID);

            builder.HasOne(p => p.Status)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.StatusId);

            builder.Property(p => p.OrderNumber)
                .IsRequired();
        }

    }

    public class BusinessConfiguration: IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasKey(p => p.ID);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(p => p.Type)
                .WithMany(p => p.Businesses)
                .HasForeignKey(p => p.BusinessTypeID);

            builder.Property(p => p.Description);
        }

    }

    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.HasKey(p => p.ID);

            builder.HasOne(p => p.Business)
                .WithMany(p => p.Packages)
                .HasForeignKey(p => p.BusinessID);

            builder.HasOne(p => p.Type)
                .WithMany(p => p.Packages)
                .HasForeignKey(p => p.PackageTypeID);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Description);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.PickUpStart)
                .IsRequired();

            builder.Property(p => p.PickUpEnd)
                .IsRequired();

         }
    }

    public class OrderPackageConfiguration : IEntityTypeConfiguration<OrderPackage>
    {
        public void Configure(EntityTypeBuilder<OrderPackage> builder)
        {
            builder.HasKey(p => new { p.OrderID, p.PackageID });
            builder.HasOne(p => p.Order)
                .WithMany(p => p.Packages)
                .HasForeignKey(p => p.OrderID)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(p => p.Package)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.PackageID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.Quantity);
        }
    }
}