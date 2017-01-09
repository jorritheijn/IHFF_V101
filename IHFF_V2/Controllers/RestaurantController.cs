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
        private IRestaurantRepository RestaurantRepository = new RestaurantRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetailRestaurantpage(int Id = 3)
        {
            DetailRestaurantViewModel RestaurantDetail = RestaurantRepository.GetSpecificRestaurant(Id);

            return View(RestaurantDetail);
        }

    }
}
