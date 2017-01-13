using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF_V2.Models;
using IHFF_V2.Repositories;

namespace IHFF_V2.Controllers
{
    public class CartController : Controller
    {
        //Shows all items currently in the cart
        public ActionResult Index()
        {
            return View();
        }
        
        //Change the cart to one with two dummy items
        public ActionResult TestCart()
        {
            //Test values for the cart (they work)
            List<CartItem> cart = new List<CartItem>();
            cart.Add(new Models.CartItem(1, "test", "here", DateTime.Now, 13.37F, 3));
            cart.Add(new Models.CartItem(2, "testest", "there", DateTime.Now, 11F, 4));
            Session["cart"] = cart;
            return View("Index");
        }

        //Increments the quantity of a cart item
        public ActionResult Increment(int id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            CartItem ci = cart.First(c => c.Id == id);
            ci.Quantity++;
            return View("Index");
        }

        //Decrements the quantity of a cart item. Deletes if there's too few items in the cart
        public ActionResult Decrement(int id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            CartItem ci = cart.First(c => c.Id == id);
            if (ci.Quantity > 1)
                ci.Quantity--;
            else
                Delete(id);
            return View("Index");
        }

        //Removes an item from the cart
        public ActionResult Delete(int id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            try
            {
                cart.Remove(cart.First(c => c.Id == id));
            }
            catch(Exception e)
            {
                return View("Error");
            }
            Session["cart"] = cart;
            return View("Index");
        }

        //Calls Index after adding another item to the cart
        public ActionResult Order(int id, int quantity)
        {
            if (Session["cart"] == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem(id, quantity));
                Session["cart"] = cart;
            }
            else
            {
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                CartItem ci = cart.FirstOrDefault(c => c.Id == id);
                if (ci == null)
                    cart.Add(new CartItem(id, quantity));
                else
                    ci.Quantity += quantity;
                Session["cart"] = cart;
            }
            return View("Index");
        }

        public ActionResult EnterDetails()
        {
            ViewBag.Total = CalculateCartValue();
            return View();
        }

        [HttpPost]
        public ActionResult EnterDetails(Bestelling bestelling)
        {
            bestelling.TotaalPrijs = CalculateCartValue();
            BestellingRepository repo = new BestellingRepository();
            List<CartItem> cart = (List<CartItem>)Session["cart"];

            if (ModelState.IsValid)
            {
                repo.CreateOrder(cart, bestelling);
                return View("OrderCompleted");
            }

            return View("Index");
        } 

        public ActionResult OrderCompleted()
        {
            return View();
        }

        //Something went wrong
        public ActionResult Error()
        {
            return View();
        }

        //Calculate and return the price of the cart
        private float CalculateCartValue()
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];

            float totaal = 0;
            foreach (CartItem item in cart)
                totaal += item.Price * item.Quantity;

            return totaal;
        }
    }
}
