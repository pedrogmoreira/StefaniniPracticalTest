using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StefaniniPracticalTest.Domain.Extensions;
using StefaniniPracticalTest.Domain.Filters;
using StefaniniPracticalTest.Domain.Interfaces.Repositories;
using StefaniniPracticalTest.Domain.Interfaces.Services;
using StefaniniPracticalTest.Web.Models;

namespace StefaniniPracticalTest.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IClassificationRepository _classificationRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IUserSysRepository _userSysRepository;
        public HomeController(ICustomerService customerService, 
            IClassificationRepository classificationRepository, 
            IGenderRepository genderRepository,
            ICityRepository cityRepository,
            IRegionRepository regionRepository,
            IUserSysRepository userSysRepository)
        {
            _customerService = customerService;
            _classificationRepository = classificationRepository;
            _genderRepository = genderRepository;
            _cityRepository = cityRepository;
            _regionRepository = regionRepository;
            _userSysRepository = userSysRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Customers = _customerService.GetCustomers(User.IsInRole("Administrator"), User.Identity.GetUserId());

            LoadDropdownData();
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(CustomerFilter customerFilter)
        {
            ViewBag.Customers = _customerService.GetCustomers(customerFilter, User.IsInRole("Administrator"), User.Identity.GetUserId());
            LoadDropdownData();
            return View(customerFilter);
        }

        private void LoadDropdownData()
        {
            ViewBag.Classifications = _classificationRepository.GetAll();
            ViewBag.Genders = _genderRepository.GetAll();
            ViewBag.Cities = _cityRepository.GetAll();
            ViewBag.Regions = _regionRepository.GetAll();

            if (User.IsInRole("Administrator"))
            {
                ViewBag.Sellers = _userSysRepository.GetSellers();
                    
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
