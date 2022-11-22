using Microsoft.AspNetCore.Mvc;
using MVC_Database.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MVC_Database.Controllers
{
    public class LanguagePersonController : Controller
    {
        private static PeopleViewModel peopleViewModel = new PeopleViewModel();
        readonly MVC_DbContext _context; // creates a readonly of DbContext

        public LanguagePersonController(MVC_DbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddLanguagePerson()
        {
            ViewBag.People = new SelectList(_context.People, "Id", "Name");
            ViewBag.LanguageNames = new SelectList(_context.Languages, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult AddLanguagePerson(int personId, List<string> languages)
        {

            var language = _context.Languages.FirstOrDefault(x => x.Id.Equals(int.Parse(languages[0])));

            var person = _context.People.FirstOrDefault(x => x.Id == personId);

            person.Languages.Add(language);

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult FilterPersonCity(string filterInput)
        {
            if (filterInput == "")
            {
                return View("Index", peopleViewModel);
            }


            var filteredData = _context.People.Where(x => x.City.Name.Contains(filterInput) || (x.PhoneNumber.Contains(filterInput)) || (x.City.Country.Name.Contains(filterInput)) || (x.Name.Contains(filterInput))).Include(c => c.City).ThenInclude(C => C.Country).ToList();

            PeopleViewModel filteredModel = new PeopleViewModel();


            filteredModel.People = filteredData;

            if (filteredModel.People.Count == 0)
            {
                return View("Index");
            }

            return View("Index", filteredModel);
        }
    }
}
