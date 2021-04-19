using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StefaniniPracticalTest.Domain.Entities;
using StefaniniPracticalTest.Domain.Helpers;

namespace StefaniniPracticalTest.Data.Mappings
{
    public class UserSysMapping : IEntityTypeConfiguration<UserSys>
    {
        public void Configure(EntityTypeBuilder<UserSys> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Login)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(40)
                .IsRequired();

            builder.HasOne(x => x.UserRole)
                .WithMany(y => y.Users)
                .HasForeignKey(x => x.UserRoleId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasData(
                new UserSys
                {
                    Id = 1,
                    Login = "Administrator",
                    Email = "admin@app.com",
                    Password = PasswordHelper.GetPasswordHash("admin@123"),
                    UserRoleId = 1
                },
                new UserSys
                {
                    Id = 2,
                    Login = "Seller1",
                    Email = "seller1@app.com",
                    Password = PasswordHelper.GetPasswordHash("seller@1"),
                    UserRoleId = 2
                },
                new UserSys
                {
                    Id = 3,
                    Login = "Seller2",
                    Email = "seller2@app.com",
                    Password = PasswordHelper.GetPasswordHash("seller@2"),
                    UserRoleId = 2
                });
        }
    }
}
