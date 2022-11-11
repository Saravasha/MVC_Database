using MVC_Data.Models;
using MVC_Data.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVC_Data.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [Range(0, 100)]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? City { get; set; }


    }
}