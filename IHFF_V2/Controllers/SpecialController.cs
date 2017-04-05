using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF_V2.Repositories;
using IHFF_V2.Models;
using System.IO;

namespace IHFF_V2.Controllers
{
    public class SpecialController : Controller
    {

        private IspecialRepository SpecialRepository = new SpecialRepository();
        private IEnumerable<Event> specials = new EventRepository().GetEventsOfType("Special");

        public ActionResult Index(string searchString, string dag)
        {
            // als er gebruik is gemaakt van het searchfilter
            if (!String.IsNullOrEmpty(searchString))
            {
                //pas geselecteerdeEvents aan naar naar enkel de resultaten die het zoekwoord bevatten
                specials = specials.Where(s => s.Titel.Contains(searchString));
            }
            return View(specials);
        }

        //Als er op een DagProgramma
        public ActionResult DagProgramma(string dag, string searchString)
        {
            specials = SpecialsOpDag(dag, specials);

            if (!String.IsNullOrEmpty(searchString))
            {
                specials = specials.Where(s => s.Titel.Contains(searchString));
            }
            ViewBag.Dag = dag;
            return View(specials);
        }

        public IEnumerable<Event> SpecialsOpDag(string dag, IEnumerable<Event> specials)
        {
            DayOfWeek AangeklikteDag = DayOfWeek.Monday;
            switch (dag)
            {
                case "maandag":
                    AangeklikteDag = DayOfWeek.Monday;
                    break;

                case "dinsdag":
                    AangeklikteDag = DayOfWeek.Tuesday;
                    break;

                case "woensdag":
                    AangeklikteDag = DayOfWeek.Wednesday;
                    break;

                case "donderdag":
                    AangeklikteDag = DayOfWeek.Thursday;
                    break;

                case "vrijdag":
                    AangeklikteDag = DayOfWeek.Friday;
                    break;

                case "zaterdag":
                    AangeklikteDag = DayOfWeek.Saturday;
                    break;

                case "zondag":
                    AangeklikteDag = DayOfWeek.Sunday;
                    break;
            }
            return specials.Where(s => s.Tijd.GetValueOrDefault().DayOfWeek.Equals(AangeklikteDag));
        }

        //brian's code below
        public ActionResult DetailSpecialpage(int Id)
        {
            DetailSpecialViewModel SpecialDetail = SpecialRepository.GetSpecificSpecial(Id);

            return View(SpecialDetail);
        }

        //gets eventid and aantal, and returns action to cartcontroller
        [HttpPost]
        public ActionResult DetailSpecialpage(int id, int aantal)
        {
            if (aantal > 0)
            {
                return RedirectToAction("Order", "Cart", new { id = id, quantity = aantal });
            }
            return View("ErrorInvoerOnjuist");
        }
    }
}
