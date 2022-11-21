using Microsoft.AspNetCore.Mvc;

namespace MVC_Database.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
