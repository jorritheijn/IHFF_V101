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
            IEnumerable<Event> GefilterdeEvents = new FilmRepository().AlleFilms;

            if (dag != null)
            {
                GefilterdeEvents = new FilmRepository().FilmsOpDag(dag);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                GefilterdeEvents = new FilmRepository().FilmsOpZoekWoord(searchString,GefilterdeEvents);                     
            }

            return View(GefilterdeEvents);
        }

    }
}
