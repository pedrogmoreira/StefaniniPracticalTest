using Microsoft.EntityFrameworkCore;
using StefaniniPracticalTest.Data.Mappings;
using StefaniniPracticalTest.Domain.Entities;

namespace StefaniniPracticalTest.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
           base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserSys> UserSys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserSysMapping).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
