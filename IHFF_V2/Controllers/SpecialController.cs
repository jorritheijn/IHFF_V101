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
        //
        // GET: /SpecialOverzicht/

        private IspecialRepository SpecialRepository = new SpecialRepository();

        public ActionResult Index(string searchString, string dag)
        {

            //Default
            //Geselecteerde events zijn de events die we in de view willen weergeven
            IEnumerable<Event> geselecteerdeEvents = new SpecialRepository().AlleSpecialsEnkel;

            //Als er op een dagfilter geklikt is.
            if (dag != null)
            {
                //verwijst door naar ActionResult DagProgramma hieronder. 
                return RedirectToAction("DagProgramma", new { dag = dag });
            }

            // als er gebruik is gemaakt van het searchfilter
            if (!String.IsNullOrEmpty(searchString))
            {
                //pas geselecteerdeEvents aan naar naar enkel de resultaten die het zoekwoord bevatten
                geselecteerdeEvents = new SpecialRepository().SpecailsOpZoekWoord(searchString, geselecteerdeEvents);
            }

            return View(geselecteerdeEvents);
        }

        //Als er op een DagProgramma

        public ActionResult DagProgramma(string dag, string searchString)
        {
            IEnumerable<Event> GefilterdeEvents = new SpecialRepository().SpecialsOpDag(dag);

            if (!String.IsNullOrEmpty(searchString))
            {
                GefilterdeEvents = new SpecialRepository().SpecailsOpZoekWoord(searchString, GefilterdeEvents);
            }
            ViewBag.Dag = dag;
            return View(GefilterdeEvents);
        }

        //brian's code below
        //
        //

        public ActionResult Index(int Id)
        {
            return View();
        }

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
