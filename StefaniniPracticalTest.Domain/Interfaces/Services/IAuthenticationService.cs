using StefaniniPracticalTest.Domain.ViewModel;
using System.Security.Claims;

namespace StefaniniPracticalTest.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        bool ValidateCredentials(LoginViewModel loginViewModel);
        ClaimsPrincipal GetUserClaims(LoginViewModel loginViewModel);
    }
}
