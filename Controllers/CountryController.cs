using Microsoft.AspNetCore.Mvc;

namespace MVC_Database.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
