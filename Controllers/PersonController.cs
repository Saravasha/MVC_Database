using Microsoft.AspNetCore.Mvc;
using MVC_Data.ViewModels;


namespace MVC_Data.Controllers
{
    public class PersonController : Controller
    {
        public static PeopleViewModel iPVModel = new PeopleViewModel();


        // Used to assign id's to newly created persons added to the list.

        public static int addId = iPVModel.People.Count();

        public IActionResult PeopleView()
        {
            return View(iPVModel);
        }

        [HttpPost]
        // Depending on the input, the persons that have the city and name attributes
        // will be shown when submitting the form.
        public IActionResult FilterPersonsOnCity(string user_input)
        {

            if (user_input == "")
            {
                return View("PeopleView", iPVModel);
            }


            var filteredData = iPVModel.People.Where(x => (x.City == user_input)
                                                || (x.Name == user_input)).ToList();


            PeopleViewModel filteredModel = new PeopleViewModel();


            filteredModel.People = filteredData;

            if (filteredModel.People.Count == 0)
            {
                return View("PeopleView");
            }



            return View("PeopleView", filteredModel);
        }


        public IActionResult AddPerson(PeopleViewModel m)
        {
            if (ModelState.IsValid)
            {

                iPVModel.People.Add(new Person()
                {
                    Id = ++addId,
                    Name = m.NewPerson.Name,
                    PhoneNumber = m.NewPerson.PhoneNumber,
                    City = m.NewPerson.City
                }
                );
                ViewBag.Statement = "The following person has been added: " + m.NewPerson.Name;
            }
            else
            {


                ViewBag.Statement = "Please fill in the form above!";

            }

            return View("PeopleView", iPVModel);
        }
        public IActionResult DeletePerson(int id)
        {
            try
            {
                iPVModel.People.RemoveAt(id - 1);
                ViewBag.Statement = $"A person with id {id} has been removed.";

            }
            catch (ArgumentOutOfRangeException aa)
            {
                ViewBag.Statement = aa.Message;
            }
            finally
            {
                ViewBag.Statement = "Unable to remove person!";
            }

            return View("PeopleView", iPVModel);
        }
    }
}
