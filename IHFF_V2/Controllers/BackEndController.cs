using IHFF_V2.Models;
using IHFF_V2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF_V2.Controllers
{
    public class BackEndController : Controller
    {
        //
        // GET: /BackEnd/

        private EventRepository repos = new EventRepository();

        public ActionResult Index()
        {
            IEnumerable<Event> events = repos.GetAllEvents();
            return View(events);
        }
        public ActionResult Delete(int id = 0)
        {
            repos.DeleteEvent(id);
            return RedirectToAction("Index");
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            Event eventItem = new Event();
            eventItem = repos.GetEvent(id);
            return View(eventItem);
        }

        [HttpPost]
        public ActionResult Add(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                repos.AddEvent(eventItem);
            }           
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                repos.EditEvent(eventItem);
            }
            return RedirectToAction("Index");
        }

    }
}
