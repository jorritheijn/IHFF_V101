using IHFF_V2.Models;
using IHFF_V2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IHFF_V2.Controllers
{
    public class BackEndController : Controller
    {
        //
        // GET: /BackEnd/

        private EventRepository repos = new EventRepository();
        private IBackEndRepository BackEndrepository = new BackEndRepository();

        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Event> events = repos.GetAllEvents();
            return View(events);
        }

        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            repos.DeleteEvent(id);
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            Event eventItem = new Event();
            eventItem = repos.GetEvent(id);
            return View(eventItem);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Add(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                repos.AddEvent(eventItem);
            }           
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                repos.EditEvent(eventItem);
            }
            return RedirectToAction("Index");
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Medewerker medewerker)
        {
            if (ModelState.IsValid)
            {
                //get account with credentials
                medewerker = BackEndrepository.GetAccount(medewerker.Gebruikersnaam, medewerker.Wachtwoord);

                if (medewerker != null)
                {
                    FormsAuthentication.SetAuthCookie(medewerker.Gebruikersnaam, false);

                    //remember account
                    Session["loggedin_medewerker"] = medewerker;

                    return RedirectToAction("Index");// goes to backend index if from is filled correctly
                }

            }
            else
            {
                ModelState.AddModelError("login-error","De gebruikersnaaam of wachtwoord is incorrect ingevoerd");
            }


            return View(medewerker);//there was a error, go back to login page
            
        }

    }
}
