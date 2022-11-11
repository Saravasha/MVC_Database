using System.ComponentModel.DataAnnotations;

namespace MVC_Data.Models
{
    public class Person
    {
        [Required]
        [Range(0, 100)]
        [Key]
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
