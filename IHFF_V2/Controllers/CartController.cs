using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF_V2.Models;

namespace IHFF_V2.Controllers
{
    public class CartController : Controller
    {
        //Shows all items currently in the cart
        public ActionResult Index()
        {
            return View();
        }

        //Function for adding items to cart
        //HAS TO BE USED IN //OTHER// CONTROLLERS!
        public ActionResult Order()
        {
            if(Session["cart"] == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem());
                Session["cart"] = cart;
            }
            else
            {

            }
            return View();
        }
    }
}
