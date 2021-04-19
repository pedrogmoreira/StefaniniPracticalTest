using Microsoft.AspNetCore.Authentication.Cookies;
using StefaniniPracticalTest.Domain.Entities;
using StefaniniPracticalTest.Domain.Helpers;
using StefaniniPracticalTest.Domain.Interfaces.Repositories;
using StefaniniPracticalTest.Domain.Interfaces.Services;
using StefaniniPracticalTest.Domain.ViewModel;
using System.Collections.Generic;
using System.Security.Claims;

namespace StefaniniPracticalTest.Data.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserSysRepository _userSysRepository;
        public AuthenticationService(IUserSysRepository userSysRepository)
        {
            _userSysRepository = userSysRepository;
        }

        /// <summary>
        /// Validate a user credentials,
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        public bool ValidateCredentials(LoginViewModel loginViewModel)
        {
            UserSys user = _userSysRepository.Find(loginViewModel.Email);

            if (user == null)
            {
                return false;
            }

            return PasswordHelper.IsPasswordValid(loginViewModel.Password, user.Password);
        }

        /// <summary>
        /// Gets the claims of a user to be authenticated.
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        public ClaimsPrincipal GetUserClaims(LoginViewModel loginViewModel)
        {
            UserSys user = _userSysRepository.Find(loginViewModel.Email);

            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.UserRole.Name)
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            return new ClaimsPrincipal(new[] { claimsIdentity });
        }
    }
}
