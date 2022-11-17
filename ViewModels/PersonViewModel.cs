using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVC_Database.ViewModels
{
    public class PersonViewModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public int CityId { get; set; }
    }
}
