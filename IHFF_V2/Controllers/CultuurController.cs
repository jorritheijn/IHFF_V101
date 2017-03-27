using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF_V2.Models;
using IHFF_V2.Repositories;

namespace IHFF_V2.Controllers
{
    public class CultuurController : Controller
    {
        private ICultuurRepository cultuurRepository = new CultuurRepository();

        public ActionResult Index()
        {
            IEnumerable<Event> allCultuurEvents = cultuurRepository.GetAllCultuurEvents();

            return View(allCultuurEvents);
        }

        public ActionResult DetailedCultuurPage(int Id)
        {
            Event SpecificEvent = cultuurRepository.GetSingleCultuurEvent(Id);

            if (SpecificEvent != null && SpecificEvent.Type == "Cultuur") {
                return View(SpecificEvent);
            }
            else {
                return View("~/Views/Shared/WrongIdError.cshtml");
            }
            
        }

    }
}
