using System.ComponentModel.DataAnnotations;
using MVC_Data.Models;

namespace MVC_Data.ViewModels
{
    public class CreatePersonViewModel
    {

        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}