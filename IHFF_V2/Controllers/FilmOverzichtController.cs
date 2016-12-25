using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF_V2.Models;
using IHFF_V2.Repositories;

namespace IHFF_V2.Controllers
{
    public class FilmOverzichtController : Controller
    {
        //
        // GET: /FilmOverzicht/


        public ActionResult Index(string searchString, string dag)
        {
            IEnumerable<Event> GefilterdeEvents = new FilmRepository().AlleFilmsEnkel;

            if (dag != null)
            {
                return RedirectToAction("DagProgramma", new { dag = dag });
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                GefilterdeEvents = new FilmRepository().FilmsOpZoekWoord(searchString,GefilterdeEvents);                     
            }

            return View(GefilterdeEvents);
        }

        public ActionResult DagProgramma(string dag, string searchString)
        {
            IEnumerable<Event> GefilterdeEvents = new FilmRepository().FilmsOpDag(dag);

            if (!String.IsNullOrEmpty(searchString))
            {
                GefilterdeEvents = new FilmRepository().FilmsOpZoekWoord(searchString, GefilterdeEvents);
            }

            ViewBag.Dag = dag; 

            return View(GefilterdeEvents);

        }
    }
}
