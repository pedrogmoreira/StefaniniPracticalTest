using StefaniniPracticalTest.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace StefaniniPracticalTest.Domain.Interfaces.Repositories
{
    public interface IRegionRepository : IRepository<Region>
    {
        IQueryable<Region> GetRegions(int cityId);
    }
}
