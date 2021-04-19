using StefaniniPracticalTest.Domain.Entities;
using StefaniniPracticalTest.Domain.Filters;
using System.Linq;

namespace StefaniniPracticalTest.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetCustomers(bool isAdmin, int userId = 0);
        IQueryable<Customer> GetCustomers(CustomerFilter customerFilter, bool isAdmin, int userId = 0);
    }
}
