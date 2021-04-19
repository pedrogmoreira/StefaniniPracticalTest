using Microsoft.EntityFrameworkCore;
using StefaniniPracticalTest.Data.Context;
using StefaniniPracticalTest.Domain.Entities;
using StefaniniPracticalTest.Domain.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace StefaniniPracticalTest.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets a list of all customers.
        /// </summary>
        public override IQueryable<Customer> GetAll()
        {
            return _dbSet
                .Include(x => x.Classification)
                .Include(x => x.Gender)
                .Include(x => x.City)
                .Include(x => x.Region)
                .Include(x => x.User)
                .AsNoTracking();
        }

        /// <summary>
        /// Finds a customer with the given primary key value.
        /// </summary>
        /// <param name="id">The value of the primary key for the entity to be found.</param>
        public override Customer Find(int id)
        {
            return _dbSet
                .Include(x => x.Gender)
                .Include(x => x.City)
                .Include(x => x.Region)
                .Include(x => x.User)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        /// <summary>
        /// Finds a customer with the given primary key value asynchronously.
        /// </summary>
        /// <param name="id">The value of the primary key for the entity to be found.</param>
        public override async Task<Customer> FindAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Gender)
                .Include(x => x.City)
                .Include(x => x.Region)
                .Include(x => x.User)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
