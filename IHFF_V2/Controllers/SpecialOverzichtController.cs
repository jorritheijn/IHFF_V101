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
    public class SpecialOverzichtController : Controller
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

        public ActionResult AddImage(int Id)
        {
            ViewBag.id = Id;
            ViewBag.Message = "not clicked";
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(int Id, HttpPostedFileBase uploadImages)
        {
            if (uploadImages == null)
            {
                ViewBag.Message = "Selecteer een bestand";
            }

            else if (uploadImages.ContentType != "image/png")
            {
                ViewBag.Message = "Alleen afbeeldingen worden geaccepteerd ";
            }

            else
            {
                FilmRepository filmrepo = new FilmRepository();
                ViewBag.id = Id;
                ViewBag.Message = "clicked";
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadImages.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImages.ContentLength);
                    filmrepo.AddPicture(imageData, Id);
                }
            }
            return View();
        }


        public ActionResult DetailSpecialpage(int Id)
        {
            DetailSpecialViewModel SpecialDetail = SpecialRepository.GetSpesificSpecial(Id);

            return View(SpecialDetail);
        }

    }
}
