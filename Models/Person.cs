using System.ComponentModel.DataAnnotations;
namespace MVC_Data
{
    public class Person
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
    }
}
