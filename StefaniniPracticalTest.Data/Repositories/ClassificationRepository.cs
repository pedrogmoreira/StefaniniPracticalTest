using StefaniniPracticalTest.Data.Context;
using StefaniniPracticalTest.Domain.Entities;
using StefaniniPracticalTest.Domain.Interfaces.Repositories;

namespace StefaniniPracticalTest.Data.Repositories
{
    public class ClassificationRepository : BaseRepository<Classification>, IClassificationRepository
    {
        public ClassificationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
