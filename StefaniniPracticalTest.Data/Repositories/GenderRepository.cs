using StefaniniPracticalTest.Data.Context;
using StefaniniPracticalTest.Domain.Entities;
using StefaniniPracticalTest.Domain.Interfaces.Repositories;

namespace StefaniniPracticalTest.Data.Repositories
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
