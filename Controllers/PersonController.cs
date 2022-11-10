using Microsoft.AspNetCore.Mvc;
using MVC_Data.ViewModels;
using MVC_Data.Models;


namespace MVC_Data.Controllers
{
    public class PersonController : Controller
    {
        public static PersonViewModel person = new PersonViewModel();

        public static int adder = person.People.Count();

        public IActionResult Index()
        {
            return View(person);
        }

        [HttpPost]
        public IActionResult FilterPersonCity(string filterInput)
        {

            if (filterInput == "")
            {
                return View("Index", person);
            }


            var filteredData = person.People.Where(x => (x.City == filterInput) || (x.Name == filterInput)).ToList();

            PersonViewModel filteredModel = new PersonViewModel();


            filteredModel.People = filteredData;

            if (filteredModel.People.Count == 0)
            {
                return View("Index");
            }



            return View("Index", filteredModel);
        }

        public IActionResult AddPerson(PersonViewModel m)
        {
            if (ModelState.IsValid)
            {

                person.People.Add(new Person()
                {
                    Id = ++adder,
                    Name = m.NewPerson.Name,
                    PhoneNumber = m.NewPerson.PhoneNumber,
                    City = m.NewPerson.City
                }
                );
                ViewBag.Statement = $"{m.NewPerson.Name} has been added to the table!";
            }
            else {
                ViewBag.Statement = "Please fill in the form above!";
            }

            return View("Index", person);
        }

        public IActionResult DeletePerson(int id, string name)
        {
            static string OrdinalSuffixGetter(int id)
            {
                string number = id.ToString();
                if (number.EndsWith("11")) return "th";
                if (number.EndsWith("12")) return "th";
                if (number.EndsWith("13")) return "th";
                if (number.EndsWith("1")) return "st";
                if (number.EndsWith("2")) return "nd";
                if (number.EndsWith("3")) return "rd";
                return "th";
            }
            if (!id.Equals(null))
            {
                try
                {
                    Person? p = person.People.FirstOrDefault(p => p.Id == id);
                    person.People.Remove(p);
                    ViewBag.Statement = $" OMG! They killed {name} the {id}{OrdinalSuffixGetter(id)}! You bastards!";

                }
                catch (ArgumentOutOfRangeException aa)
                {
                    ViewBag.Statement = aa.Message;
                }
            }
            else
            {
                ViewBag.Statement = "Unable to remove person!";
            }

            return View("Index", person);
        }

    }

}
