using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StefaniniPracticalTest.Domain.Entities;

namespace StefaniniPracticalTest.Data.Mappings
{
    public class RegionMapping : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasData(
                new Region
                {
                    Id = 1,
                    Name = "Rio Grande do Sul"
                },
                new Region
                {
                    Id = 2,
                    Name = "São Paulo"
                },
                new Region
                {
                    Id = 3,
                    Name = "Curitiba"
                });
        }
    }
}
