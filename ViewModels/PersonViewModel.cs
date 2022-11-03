using MVC_Data.Models;

namespace MVC_Data.ViewModels
{
public class PersonViewModel
    {
        public CreatePersonViewModel NewPerson { get; set; }

        public List<Person> People = new List<Person>();
        public PersonViewModel()
        {
            NewPerson = new CreatePersonViewModel();
            GetPeople();
        }
        
        // Seedar in lite dudes
        public List<Person> GetPeople()
        {

            People.Add(new Person { Id = 1, Name = "Siavash Gosheh", PhoneNumber = "xxxx-xxx666", City = "Gothenburg"});
            People.Add(new Person { Id = 2, Name = "Maxwell T Bird", PhoneNumber = "Mr. Max Tv @ Youtube", City = "Central Pennsylvania"});
            People.Add(new Person { Id = 3, Name = "Nergal", PhoneNumber = "666", City = "Gdansk"});
            return People;


        }
    }
}