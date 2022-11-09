using Microsoft.AspNetCore.Mvc;
using MVC_Data.ViewModels;
using MVC_Data.Models;
using MVC_Data.Controllers;

namespace MVC_Data.Controllers
{
    public class AjaxController : Controller
    {
        public static PersonViewModel person = new PersonViewModel();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetPeople() { 
            
            return PartialView("_PersonHeaderPartial", person); 
        }

        public IActionResult GetPeople(int id)
        {
            var filteredData = person.People.Where(x => x.Id == id).ToList();


            PersonViewModel filteredModel = new PersonViewModel();


            filteredModel.People = filteredData;

            if (filteredModel.People.Count == 0)
            {
                return View("_PersonHeaderPartial");
            }

            return View("_PersonHeaderPartial", filteredModel);

        }

        [HttpPost]
        public IActionResult DeletePeople(int id, string name)
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

            return View("_PersonHeaderPartial", person);
        }
    }

}
