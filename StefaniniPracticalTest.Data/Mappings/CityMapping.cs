using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StefaniniPracticalTest.Domain.Entities;

namespace StefaniniPracticalTest.Data.Mappings
{
    public class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(x => x.Region)
                .WithMany(y => y.Cities)
                .HasForeignKey(x => x.RegionId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasData(
                new City
                {
                    Id = 1,
                    Name = "Porto Alegre",
                    RegionId = 1
                });
        }
    }
}
