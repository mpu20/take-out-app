using System.ComponentModel.DataAnnotations;

namespace TakeOutApp.API.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required, Phone]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string Role { get; set; } = null!;
    }
}
