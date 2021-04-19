using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using StefaniniPracticalTest.Domain.ViewModel;

namespace StefaniniPracticalTest.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly Domain.Interfaces.Services.IAuthenticationService _authenticationService;

        public AuthenticationController(Domain.Interfaces.Services.IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginViewModel loginViewModel, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            if (_authenticationService.ValidateCredentials(loginViewModel))
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, _authenticationService.GetUserClaims(loginViewModel));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Credentials", "The email and / or password entered is invalid.Please try again.");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", new { ReturnUrl = "%2F" });
            }
    }
}
