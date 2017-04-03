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
        private RestaurantRepository restaurantRepos = new RestaurantRepository();
        private FilmRepository filmRepos = new FilmRepository();
        private CultuurRepository cultuurRepos = new CultuurRepository();
        private SpecialRepository specialRepos = new SpecialRepository();
        private byte[] poster;

        [Authorize]
        public ActionResult Index()
        {

            IEnumerable<Event> films = repos.GetAllEventsOfType("Film");
            IEnumerable<Event> restaurants = repos.GetAllEventsOfType("Restaurant");
            IEnumerable<Event> specials = repos.GetAllEventsOfType("Special");
            IEnumerable<Event> cultuur = repos.GetAllEventsOfType("Cultuur");

            IEnumerable<Event> events = films.Concat(restaurants).Concat(specials).Concat(cultuur);

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
            poster = eventItem.Poster;
            return View(eventItem);
        }
        [Authorize]
        public ActionResult BewerkFilm(int id)
        {
            DetailFilmViewModel eventItem = new DetailFilmViewModel();
            eventItem = filmRepos.GetDetailedFilm(id);
            poster = eventItem.Event.Poster;
            return View(eventItem);
        }
        [Authorize]
        public ActionResult BewerkRestaurant(int id)
        {
            DetailRestaurantViewModel eventItem = new DetailRestaurantViewModel();
            eventItem = restaurantRepos.GetSpecificRestaurant(id);
            return View(eventItem);
        }
        [Authorize]
        public ActionResult BewerkSpecial(int id)
        {
            DetailSpecialViewModel eventItem = new DetailSpecialViewModel();
            eventItem = specialRepos.GetSpecificSpecial(id);
            return View(eventItem);
        }
        [Authorize]
        public ActionResult BewerkCultuur(int id)
        {
            Event eventItem = new Event();
            eventItem = cultuurRepos.GetSingleCultuurEvent(id);
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
        [Authorize]
        [HttpPost]
        public ActionResult BewerkFilm(DetailFilmViewModel eventItem)
        {
            if(ModelState.IsValid)
            {
                eventItem.Event.Poster = poster;
                repos.EditEvent(eventItem.Event);
                filmRepos.EditFilm(eventItem.Film);
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
                Medewerker medewerkeraccount = BackEndrepository.GetAccount(medewerker.Gebruikersnaam, medewerker.Wachtwoord);

                if (medewerker != null)
                {
                    FormsAuthentication.SetAuthCookie(medewerkeraccount.Gebruikersnaam, false);

                    //remember account
                    Session["loggedin_medewerker"] = medewerkeraccount;

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
