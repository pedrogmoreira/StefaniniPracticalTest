using StefaniniPracticalTest.Data.Context;
using StefaniniPracticalTest.Domain.Entities;
using StefaniniPracticalTest.Domain.Interfaces.Repositories;

namespace StefaniniPracticalTest.Data.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context)
        {
        } 
    }
}
