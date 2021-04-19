using System.Collections.Generic;

namespace StefaniniPracticalTest.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int RegionId { get; set; }

        public Region Region { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
