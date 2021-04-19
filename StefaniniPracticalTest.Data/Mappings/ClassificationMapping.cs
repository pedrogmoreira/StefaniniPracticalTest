using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StefaniniPracticalTest.Domain.Entities;

namespace StefaniniPracticalTest.Data.Mappings
{
    public class ClassificationMapping : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasData(
                new Classification
                {
                    Id = 1,
                    Name = "VIP"
                },
                new Classification
                {
                    Id = 2,
                    Name = "Regular"
                },
                new Classification
                {
                    Id = 3,
                    Name = "Sporadic"
                });
        }
    }
}
