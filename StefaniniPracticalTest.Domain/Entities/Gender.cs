using System.Collections.Generic;

namespace StefaniniPracticalTest.Domain.Entities
{
    public class Gender : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}
