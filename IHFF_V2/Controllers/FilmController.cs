using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF_V2.Models;
using IHFF_V2.Repositories;
using System.IO;


namespace IHFF_V2.Controllers
{
    public class FilmController : Controller
    {
        private IFilmRepository filmrepository = new FilmRepository();

        public ActionResult Index(string searchString, string dag)
        {
            //Geselecteerde events zijn de events die we in de view willen weergeven
            IEnumerable<Event> geselecteerdeEvents = new FilmRepository().AlleFilmsEnkel;

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
                geselecteerdeEvents = new FilmRepository().FilmsOpZoekWoord(searchString, geselecteerdeEvents);
            }
            return View(geselecteerdeEvents);
        }

        //Als er op een DagProgramma is gelklikt
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

        

        //Haalt detailpagina op 
        public ActionResult DetailFilmpage(int Id)
        {
            DetailFilmViewModel FilmDetail = filmrepository.GetDetailedFilm(Id);

            if (FilmDetail.Event != null && FilmDetail.Event.Type == "Film") {
                return View(FilmDetail);
            }
            else {
                return View("~/Views/Shared/WrongIdError.cshtml");
            }

            
        }

        // gets event id and aantal from form, returns action to cartcontroller
        [HttpPost]
        public ActionResult DetailFilmpage(int id, int aantal)
        {
            if (aantal > 0)
            {
                return RedirectToAction("Order", "Cart", new { id = id, quantity = aantal });
            }

            return View("ErrorInvoerOnjuist");
        }
    }
}

