using IHFF_V2.Models;
using IHFF_V2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF_V2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Event> films = new FilmRepository().AlleFilms;
            IEnumerable<Event> restaurants = new RestaurantRepository().AlleRestaurants;
            IEnumerable<Event> specials = new SpecialRepository().AlleSpecials;

            List<Event> allefilms = films.ToList();
            List<Event> allerestaurants = restaurants.ToList();
            List<Event> allespecials = specials.ToList();

            List<Event> getoondeEvents = new List<Event>();
            Random rnd = new Random();

            getoondeEvents.Add(allerestaurants[rnd.Next(0, allerestaurants.Count)]);
            getoondeEvents.Add(allerestaurants[rnd.Next(0, allerestaurants.Count)]);
            while (getoondeEvents[0] == getoondeEvents[1])
            {
                getoondeEvents[1] = allerestaurants[rnd.Next(0, allerestaurants.Count)];
            }
            getoondeEvents.Add(allefilms[rnd.Next(0, allefilms.Count)]);
            getoondeEvents.Add(allefilms[rnd.Next(0, allefilms.Count)]);
            while (getoondeEvents[2] == getoondeEvents[3])
            {
                getoondeEvents[1] = allefilms[rnd.Next(0, allefilms.Count)];
            }
            getoondeEvents.Add(allespecials[rnd.Next(0, allespecials.Count)]);
            getoondeEvents.Add(allespecials[rnd.Next(0, allespecials.Count)]);
            while (getoondeEvents[4] == getoondeEvents[5])
            {
                getoondeEvents[5] = allespecials[rnd.Next(0, allespecials.Count)];
            }
            return View(getoondeEvents);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            //test
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
