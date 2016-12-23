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

        public ActionResult Index(string searchString)
        {
            IEnumerable<Event> GevilterdeEvents = new DbEventRepository().GetAllEvents();

            if (!String.IsNullOrEmpty(searchString))
            {
                GevilterdeEvents = new DbEventRepository().eventsopnaam(searchString);
            }

            
            
            return View(GevilterdeEvents);
        }


    }
}
