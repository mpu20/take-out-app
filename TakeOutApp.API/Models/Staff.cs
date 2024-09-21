using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TakeOutApp.API.Common;

namespace TakeOutApp.API.Models
{
    public class Staff
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public StaffRole Role { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
