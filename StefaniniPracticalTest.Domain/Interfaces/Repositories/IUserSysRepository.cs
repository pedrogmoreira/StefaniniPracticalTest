using StefaniniPracticalTest.Domain.Entities;
using System.Linq;

namespace StefaniniPracticalTest.Domain.Interfaces.Repositories
{
    public interface IUserSysRepository : IRepository<UserSys>
    {
        UserSys Find(string email);
        IQueryable<UserSys> GetSellers();
    }
}
