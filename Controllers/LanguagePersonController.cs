﻿using Microsoft.AspNetCore.Mvc;
using MVC_Database.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MVC_Database.Controllers
{
    public class LanguagePersonController : Controller
    {
        private static CreatePeopleViewModel peopleViewModel = new CreatePeopleViewModel();
        readonly MVC_DbContext _context; // creates a readonly of DbContext

        public LanguagePersonController(MVC_DbContext context)
        {
            _context = context;
        }


        public IActionResult AddLanguagePerson()
        {
            ViewBag.PeopleNames = new SelectList(_context.People, "Id", "Name");
            ViewBag.LanguageNames = new SelectList(_context.Languages, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult AddLanguagePerson(string personId, List<string> languages)
        {

            var person = _context.People.FirstOrDefault(x => x.Id == int.Parse(personId));
            foreach (var lang in languages)
            {
                var language = _context.Languages.FirstOrDefault(x => x.Id.Equals(int.Parse(lang)));

                try
                {
                    person.Languages.Add(language);

                    _context.SaveChanges();
                }
                catch (DbUpdateException e)
                {

                    ViewBag.Statement = e.Message;
                }
            }

            return RedirectToAction("AddLanguagePerson");

        }


    }
}
