using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StefaniniPracticalTest.Domain.Entities;

namespace StefaniniPracticalTest.Data.Mappings
{
    public class GenderMapping : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(10)
                .IsRequired();

            builder.HasData(
                new Gender
                {
                    Id = 1,
                    Name = "Masculine"
                },
                new Gender
                {
                    Id = 2,
                    Name = "Feminine"
                });
        }
    }
}
