using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StefaniniPracticalTest.Domain.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password is Required")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
