using System.Collections.Generic;

namespace StefaniniPracticalTest.Domain.Entities
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
