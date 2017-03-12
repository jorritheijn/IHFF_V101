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
    public class FilmOverzichtController : Controller
    {
        private IFilmRepository filmrepository = new FilmRepository();
        private EventRepository eventrepository = new EventRepository();
        private IEnumerable<Event> films = new EventRepository().GetEventsOfType("film");

        public ActionResult Index(string searchString, string dag)
        {
            // als er gebruik is gemaakt van het searchfilter
            if (!String.IsNullOrEmpty(searchString))
            {
                //pas geselecteerdeEvents aan naar naar enkel de resultaten die het zoekwoord bevatten
                films = films.Where(s => s.Titel.Contains(searchString));
            }
            return View(films);
        }

        //Als er op een DagProgramma is gelklikt
        public ActionResult DagProgramma(string dag, string searchString)
        {
            films = FilmsOpDag(dag, films);

            if (!String.IsNullOrEmpty(searchString))
            {
                films = films.Where(s => s.Titel.Contains(searchString));
            }
            ViewBag.Dag = dag;
            return View(films);
        }

        public IEnumerable<Event> FilmsOpDag(string dag, IEnumerable<Event> film)
        {
            DayOfWeek AangeklikteDag = DayOfWeek.Monday;
            switch (dag)
            {
                case "maandag": AangeklikteDag = DayOfWeek.Monday;
                    break;

                case "dinsdag": AangeklikteDag = DayOfWeek.Tuesday;
                    break;

                case "woensdag": AangeklikteDag = DayOfWeek.Wednesday;
                    break;

                case "donderdag": AangeklikteDag = DayOfWeek.Thursday;
                    break;

                case "vrijdag": AangeklikteDag = DayOfWeek.Friday;
                    break;

                case "zaterdag": AangeklikteDag = DayOfWeek.Saturday;
                    break;

                case "zondag": AangeklikteDag = DayOfWeek.Sunday;
                    break;

            }
            return film.Where(s => s.Tijd.Value.DayOfWeek.Equals(AangeklikteDag));
        }





        //public ActionResult AddImage(int Id)
        //{
        //    ViewBag.id = Id;
        //    ViewBag.Message = "not clicked";
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddImage(int Id, HttpPostedFileBase uploadImages)
        //{
        //    if (uploadImages == null)
        //    {
        //        ViewBag.Message = "Selecteer een bestand";
        //    }

        //    /*else if (uploadImages.ContentType != "image/png")
        //    {
        //        ViewBag.Message = "Alleen afbeeldingen worden geaccepteerd ";
        //    }*/

        //    else
        //    {
        //        FilmRepository filmrepo = new FilmRepository();
        //        ViewBag.id = Id;
        //        ViewBag.Message = "clicked";
        //        byte[] imageData = null;
        //        using (var binaryReader = new BinaryReader(uploadImages.InputStream))
        //        {
        //            imageData = binaryReader.ReadBytes(uploadImages.ContentLength);
        //            filmrepo.AddPicture(imageData, Id);
        //        }
        //    }
        //    return View();
        //}

        //Haalt detailpagina op 
        public ActionResult DetailFilmpage(int Id)
        {
            DetailFilmViewModel FilmDetail = filmrepository.GetDetailedFilm(Id);

            return View(FilmDetail);
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

