using Microsoft.AspNetCore.Mvc;
using MVC_Data.ViewModels;
using MVC_Data.Models;
using MVC_Data.Controllers;

namespace MVC_Data.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetDetails(Person p)
        {
            //Person w = p.People(x => x.Id == id);

            //return PartialView("_PersonPartial", id);
            return View();
        }

        public IActionResult GetPeople(Person p)
        {
            //Person w = p.People(x => x.Id == id);

            //return PartialView("_PersonPartial", id);
            return View();
        }

        public IActionResult DeletePeople(Person p)
        {
            //Person w = p.People(x => x.Id == id);

            //return PartialView("_PersonPartial", id);
            return View();
        }
    }

}
