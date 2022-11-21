using MVC_Data.Models;
namespace MVC_Database.ViewModels
{
	public class LanguageViewModel
	{

		public string Name { get; set; }
		public List<Person> People { get; set; } = new List<Person>();
	}
}
