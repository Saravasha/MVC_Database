using Microsoft.AspNetCore.Mvc;
using MVC_Data.ViewModels;
using MVC_Data.Models;

namespace MVC_Data.Controllers
{
    public class AjaxController : Controller
    {
        public static PersonViewModel person = new PersonViewModel();


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPeople() { 
            
            return PartialView("_PersonPartial", person); 
        }

        [HttpPost]
        public IActionResult GetPeople(int id)
        {
            var filteredData = person.People.Where(x => x.Id == id).ToList();


            PersonViewModel filteredModel = new PersonViewModel();


            filteredModel.People = filteredData;

            if (filteredModel.People.Count == 0)
            {
                return View("_PersonPartial");
            }

            return View("_PersonPartial", filteredModel);

        }

        [HttpPost]
        public IActionResult AnnihilatePerson(int id)
        {
            static string OrdinalSuffixGetter(int Id)
            {
                string number = Id.ToString();
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
                    if(p!=null)
                    {
                        
                    ViewBag.Statement = $" OMG! They killed {p.Name} the {p.Id}{OrdinalSuffixGetter(p.Id)}! You bastards!";
                    }

                }
                catch (ArgumentOutOfRangeException aa)
                {
                    ViewBag.Statement = aa.Message;
                }
            }
            else
            {
                ViewBag.Statement = "Unable to comply!";
            }

            return View("_PersonPartial", person);
        }
    }

}
