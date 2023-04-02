using System.ComponentModel.DataAnnotations;

namespace ModelBindingDemo.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation do no match!")]
        public string ConfirmPassword { get; set; }
    }
}
