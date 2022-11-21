using System.ComponentModel.DataAnnotations;
using MVC_Data.Models;
using MVC_Database.Models;

namespace MVC_Data.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Person> People { get; set; } = new List<Person>(); 
    }
}