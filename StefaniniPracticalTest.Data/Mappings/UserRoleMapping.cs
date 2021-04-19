using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StefaniniPracticalTest.Domain.Entities;

namespace StefaniniPracticalTest.Data.Mappings
{
    public class UserRoleMapping : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();
            
            builder.Property(x => x.IsAdmin)
                .IsRequired();

            builder.HasData(
                new UserRole
                {
                    Id = 1,
                    Name = "Administrator",
                    IsAdmin = true
                },
                new UserRole
                {
                    Id = 2,
                    Name = "Seller ",
                    IsAdmin = false
                });
        }
    }
}
