using StefaniniPracticalTest.Domain.Entities;
using StefaniniPracticalTest.Domain.Filters;
using StefaniniPracticalTest.Domain.Interfaces.Repositories;
using StefaniniPracticalTest.Domain.Interfaces.Services;
using System.Linq;

namespace StefaniniPracticalTest.Data.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Gets a list of customers.
        /// </summary>
        /// <param name="isAdmin">Authenticated user is Admin</param>
        /// <param name="userId">Authenticated user ID</param>
        /// <returns></returns>
        public IQueryable<Customer> GetCustomers(bool isAdmin, int userId = 0)
        {
            IQueryable<Customer> customers = _customerRepository.GetAll();

            if (!isAdmin)
            {
                customers = customers.Where(x => x.UserId == userId);
            }

            return customers;
        }

        /// <summary>
        /// Gets a list of customers with a given filter
        /// </summary>
        /// <param name="customerFilter">The filter.</param>
        /// <param name="isAdmin">Authenticated user is Admin</param>
        /// <param name="userId">Authenticated user ID</param>>
        /// <returns></returns>
        public IQueryable<Customer> GetCustomers(CustomerFilter customerFilter, bool isAdmin, int userId = 0)
        {
            IQueryable<Customer> customers = _customerRepository.GetAll();

            if (!isAdmin)
            {
                customers = customers.Where(x => x.UserId == userId);
            }

            if (!string.IsNullOrEmpty(customerFilter.Name))
            {
                customers = customers.Where(x => x.Name.StartsWith(customerFilter.Name));
            }

            if (customerFilter.GenderId.HasValue)
            {
                customers = customers.Where(x => x.GenderId == customerFilter.GenderId);
            }

            if (customerFilter.CityId.HasValue)
            {
                customers = customers.Where(x => x.CityId == customerFilter.CityId);
            }

            if (customerFilter.RegionId.HasValue)
            {
                customers = customers.Where(x => x.RegionId == customerFilter.RegionId);
            }

            if (customerFilter.ClassificationId.HasValue)
            {
                customers = customers.Where(x => x.ClassificationId == customerFilter.ClassificationId);
            }

            if (customerFilter.LastPurchaseFrom.HasValue && customerFilter.LastPurchaseTo.HasValue)
            {
                customers = customers.Where(x => x.LastPurchase >= customerFilter.LastPurchaseFrom.Value.Date && x.LastPurchase <= customerFilter.LastPurchaseTo.Value.Date);
            }
            else if (customerFilter.LastPurchaseFrom.HasValue && !customerFilter.LastPurchaseTo.HasValue)
            {
                customers = customers.Where(x => x.LastPurchase >= customerFilter.LastPurchaseFrom.Value.Date);
            }
            else if (!customerFilter.LastPurchaseFrom.HasValue && customerFilter.LastPurchaseTo.HasValue)
            {
                customers = customers.Where(x => x.LastPurchase <= customerFilter.LastPurchaseTo.Value.Date);
            }

            if (isAdmin && customerFilter.SellerId.HasValue)
            {
                customers = customers.Where(x => x.User.Id == customerFilter.SellerId);
            }

            return customers;
        }
    }
}
