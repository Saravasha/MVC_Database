using MVC_Data.Models;
namespace MVC_Database.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; } = new List<Person>();
    }
}
