using Microsoft.AspNetCore.Mvc;
using MVC_Data.ViewModels;
using MVC_Data.Models;
using MVC_Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Database.ViewModels;

namespace MVC_Data.Controllers
{
    public class PersonController : Controller
    {
        
        private static PeopleViewModel peopleViewModel = new PeopleViewModel();
        readonly MVC_DbContext _context; // creates a readonly of DbContext

        public PersonController(MVC_DbContext context)
        {
            _context = context;
        }

  

        public IActionResult Index()
        {
            ViewBag.CityNames = new SelectList(_context.Cities, "Id", "Name");
            peopleViewModel.People = _context.People.Include(c => c.City).ThenInclude(z => z.Country).ToList();



            return View(peopleViewModel);
        }
 

        [HttpPost]
        public IActionResult FilterPersonCity(string filterInput)
        {

            if (filterInput == "")
            {
                return View("Index", peopleViewModel);
            }


            var filteredData = _context.People.Where(x => x.City.Name.Contains(filterInput) || (x.Name.Contains(filterInput))).Include(c => c.City).ToList();

            PeopleViewModel filteredModel = new PeopleViewModel();


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

                _context.People.Add(new Person()
                {
                   
                    Name = m.Name,
                    PhoneNumber = m.PhoneNumber,
                    CityId = m.CityId,


                });
                _context.SaveChanges();

                ViewBag.Statement = $"{m.Name} has been added to the table!";
            }
            else {
                ViewBag.Statement = "Please fill in the form above!";
            }

            return View("Index", peopleViewModel);
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
                    Person? p = peopleViewModel.People.FirstOrDefault(p => p.Id == id);
                    _context.People.Remove(p);
                    _context.SaveChanges();
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

            return View("Index", peopleViewModel);
        }

    }

}
