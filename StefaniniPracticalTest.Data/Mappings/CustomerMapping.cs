using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StefaniniPracticalTest.Domain.Entities;
using System;

namespace StefaniniPracticalTest.Data.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Gender)
                .WithMany(y => y.Customers)
                .HasForeignKey(x => x.GenderId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.City)
                .WithMany(y => y.Customers)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Region)
                .WithMany(y => y.Customers)
                .HasForeignKey(x => x.RegionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.LastPurchase)
                .HasColumnType("date");

            builder.HasOne(x => x.Classification)
                .WithMany(y => y.Customers)
                .HasForeignKey(x => x.ClassificationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithMany(y => y.Customers)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Maurício",
                    Phone = "(11) 95429999",
                    GenderId = 1,
                    CityId = 1,
                    RegionId = 1,
                    LastPurchase = DateTime.Parse("2016-09-10"),
                    ClassificationId = 1,
                    UserId = 3
                },
                new Customer
                {
                    Id = 2,
                    Name = "Carla",
                    Phone = "(53) 94569999",
                    GenderId = 2,
                    CityId = 1,
                    RegionId = 1,
                    LastPurchase = DateTime.Parse("2015-10-10"),
                    ClassificationId = 1,
                    UserId = 2
                },
                new Customer
                {
                    Id = 3,
                    Name = "Maria",
                    Phone = "(64) 94518888",
                    GenderId = 2,
                    CityId = 1,
                    RegionId = 1,
                    LastPurchase = DateTime.Parse("2013-10-12"),
                    ClassificationId = 3,
                    UserId = 2
                },
                new Customer
                {
                    Id = 4,
                    Name = "Douglas",
                    Phone = "(51) 12455555",
                    GenderId = 1,
                    CityId = 1,
                    RegionId = 1,
                    LastPurchase = DateTime.Parse("2016-05-05"),
                    ClassificationId = 2,
                    UserId = 2
                },
                new Customer
                {
                    Id = 5,
                    Name = "Marta",
                    Phone = "(51) 45788888",
                    GenderId = 2,
                    CityId = 1,
                    RegionId = 1,
                    LastPurchase = DateTime.Parse("2016-08-08"),
                    ClassificationId = 2,
                    UserId = 3
                });
        }
    }
}
