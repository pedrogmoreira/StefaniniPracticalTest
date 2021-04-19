using System.Collections.Generic;

namespace StefaniniPracticalTest.Domain.Entities
{
    public class UserSys : BaseEntity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
