using System.Collections.Generic;

namespace StefaniniPracticalTest.Domain.Entities
{
    public class UserRole: BaseEntity
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        public IEnumerable<UserSys> Users { get; set; }
    }
}
