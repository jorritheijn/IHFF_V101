using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;
using IHFF_V2.Repositories;
using System.Web.Mvc;

namespace IHFF_V2.Controllers
{
    public class RestaurantController : Controller
    {

        private RestaurantRepository RestaurantRepository = new RestaurantRepository();
        private EventRepository EventRepository = new EventRepository();
        private IEnumerable<Event> restaurants = new EventRepository().GetEventsOfType("Restaurant"); 

        //restaurantoverzicht
        public ActionResult Index()
        {            
            return View(restaurants);
        }

        //haalt restaurantpagina op
        public ActionResult DetailRestaurantpage(int Id)
        {
            DetailRestaurantViewModel RestaurantDetail = RestaurantRepository.GetSpecificRestaurant(Id);

            if (RestaurantDetail != null && RestaurantDetail.Event.Type == "Restaurant")
            {
                return View(RestaurantDetail);
            }
            else
            {
                return View("~/Views/Shared/WrongIdError.cshtml");
            }
        }
              
        //gets event id and aantal, returns action to cartcontroller
        [HttpPost]
        public ActionResult DetailRestaurantpage(int id, DateTime? time ,int aantal)
        {
            Event correctEvent;

            if (time != null)
            {
                correctEvent = EventRepository.GetCorrectEventForCart(id, time);
            }
            else {
                return View("~/Views/Shared/ErrorNoDate.cshtml");
            }

            if (aantal > 0)
            {
                return RedirectToAction("Order", "Cart", new { id = correctEvent.Id, quantity = aantal });
            }
            return View("ErrorInvoerOnjuist");
        }

    }
}
