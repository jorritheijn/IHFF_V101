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
        //
        // GET: /Restaurant/

        //all actions with films are done via a FilmRepository
        private RestaurantRepository RestaurantRepository = new RestaurantRepository();

        public ActionResult Index()
        {
            IEnumerable<Event> restaurants = RestaurantRepository.AlleResetaurants;
            return View(restaurants);
        }

        public ActionResult DetailRestaurantpage(int Id)
        {
            DetailRestaurantViewModel RestaurantDetail = RestaurantRepository.GetSpecificRestaurant(Id);
            return View(RestaurantDetail);
        }
              
        //gets event id and aantal, returns action to cartcontroller
        [HttpPost]
        public ActionResult DetailRestaurantpage(int id, int aantal)
        {
            if (aantal > 0)
            {
                return RedirectToAction("Order", "Cart", new { id = id, quantity = aantal });
            }
            return View("ErrorInvoerOnjuist");
        }

    }
}
