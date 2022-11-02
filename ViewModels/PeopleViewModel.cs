using MVC_Data.Models;


namespace MVC_Data.ViewModels
{
public class PeopleViewModel
    {
        public CreatePersonViewModel? NewPerson { get; set; }

        public List<Person> People = new List<Person>();

        // use both new and existing data in the constructor below
        public PeopleViewModel()
        {
            NewPerson = new CreatePersonViewModel();
            GetPeople();
        }

        // return a list of people that are added to the People list in the method below.
        public List<Person>? GetPeople()
        {

            People.Add(new Person { Id = 1, Name = "Siavash Gosheh", PhoneNumber = "xxxx-xxx666", City = "Gothenburg"});
            People.Add(new Person { Id = 2, Name = "Maxwell T Bird", PhoneNumber = "Mr. Max Tv @ Youtube", City = "Central Pennsylvania"});
            People.Add(new Person { Id = 3, Name = "Nergal", PhoneNumber = "666", City = "Gdansk"});
            return People;


        }
    }
}