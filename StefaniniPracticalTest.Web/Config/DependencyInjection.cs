using Microsoft.Extensions.DependencyInjection;
using StefaniniPracticalTest.Data.Repositories;
using StefaniniPracticalTest.Data.Services;
using StefaniniPracticalTest.Domain.Interfaces.Repositories;
using StefaniniPracticalTest.Domain.Interfaces.Services;

namespace StefaniniPracticalTest.Web.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Repository Dependency Injection
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IClassificationRepository, ClassificationRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IUserSysRepository, UserSysRepository>();

            // Services Dependency Injection
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
