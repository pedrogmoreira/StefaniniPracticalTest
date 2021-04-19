using StefaniniPracticalTest.Data.Context;
using StefaniniPracticalTest.Domain.Entities;
using StefaniniPracticalTest.Domain.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace StefaniniPracticalTest.Data.Repositories
{
    public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        private readonly ICityRepository _cityRepository;
        public RegionRepository(ApplicationDbContext context, ICityRepository cityRepository) : base(context)
        {
            _cityRepository = cityRepository;
        }

        public IQueryable<Region> GetRegions(int cityId)
        {
            return _cityRepository
                .GetAll()
                .Where(x => x.Id == cityId)
                .Select(x => x.Region);
                

        }
    }
}
