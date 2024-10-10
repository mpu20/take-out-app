using System.ComponentModel.DataAnnotations;

namespace TakeOutApp.API.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
