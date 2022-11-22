using Microsoft.AspNetCore.Mvc;
using MVC_Database.Data;
using MVC_Database.Models;

namespace MVC_Database.Controllers
{
    public class LanguageController : Controller
    {
        readonly MVC_DbContext _context;
        public LanguageController(MVC_DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View(_context.Languages);
        }

        public IActionResult Create()
        {
            return View();
                
        }

        [HttpPost]
        public IActionResult Create(Language lang, string languageName)
        {
            new Language { Name = languageName };
            _context.Languages.Add(lang);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var lang = _context.Languages.FirstOrDefault(x => x.Id == id);
            if (lang != null)
            {
                _context.Languages.Remove(lang);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}
