using Microsoft.EntityFrameworkCore;
using StefaniniPracticalTest.Data.Context;
using StefaniniPracticalTest.Domain.Entities;
using StefaniniPracticalTest.Domain.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace StefaniniPracticalTest.Data.Repositories
{
    public class UserSysRepository : BaseRepository<UserSys>, IUserSysRepository
    {
        public UserSysRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Finds a user by a given email.
        /// </summary>
        /// <param name="email">The user email.</param>
        public UserSys Find(string email)
        {
            return _dbSet
                .Include(x => x.UserRole)
                .Where(x => x.Email.Equals(email))
                .FirstOrDefault();
        }

        /// <summary>
        /// Finds a user with the given primary key value.
        /// </summary>
        /// <param name="id">The value of the primary key for the entity to be found.</param>
        public override UserSys Find(int id)
        {
            return _dbSet
                .Include(x => x.UserRole)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        /// <summary>
        /// Finds an entity with the given primary key value asynchronously.
        /// </summary>
        /// <param name="id">The value of the primary key for the entity to be found.</param>
        public override async Task<UserSys> FindAsync(int id)
        {
            return await _dbSet
                .Include(x => x.UserRole)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public IQueryable<UserSys> GetSellers()
        {
            return GetAll()
                .Where(x => x.UserRole.IsAdmin == false)
                .Distinct();
        }
    }
}
