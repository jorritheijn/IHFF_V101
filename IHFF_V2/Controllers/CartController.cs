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
        /// <summary>
        /// Een overzicht van alle items aanwezig in de winkelwagen
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        
        ////Change the cart to one with two dummy items
        //public ActionResult TestCart()
        //{
        //    //Test values for the cart (they work)
        //    List<CartItem> cart = new List<CartItem>();
        //    cart.Add(new Models.CartItem(1, "test", "here", DateTime.Now, 13.37F, 3));
        //    cart.Add(new Models.CartItem(2, "testest", "there", DateTime.Now, 11F, 4));
        //    Session["cart"] = cart;
        //    return View("Index");
        //}
        
        /// <summary>
        /// Het aantal reserveringen voor een bepaald item wordt verhoogt met 1
        /// </summary>
        /// <param name="id">Het id van een CartItem</param>
        /// <returns>Terug naar het overzicht van de winkelwagen wanneer succesvol. Naar de error-page wanneer niet succesvol</returns>
        public ActionResult Increment(int id)
        {
            try
            {
                CartItem ci = GetCartItem(id);
                ci.Quantity++;
            }
            catch(Exception e)
            {
                return View("Error");
            }
            return View("Index");
        }
        
        /// <summary>
        /// Het aantal reserveringen voor een bepaald item wordt verlaagt met 1
        /// Als het aantal op 0 komt, wordt het item automatisch verwijdert uit de winkelwagen
        /// </summary>
        /// <param name="id">Het id van een CartItem</param>
        /// <returns>Terug naar het overzicht van de winkelwagen wanneer succesvol. Naar de error-page wanneer niet succesvol</returns>
        public ActionResult Decrement(int id)
        {
            try
            {
                //List<CartItem> cart = GetCartFromSession();
                //CartItem ci = cart.First(c => c.Id == id);
                CartItem ci = GetCartItem(id);
                if (ci.Quantity > 1)
                    ci.Quantity--;
                else
                    Delete(id);
            }
            catch(Exception e)
            {
                return View("Error");
            }
            return View("Index");
        }
        
        /// <summary>
        /// Verwijdert een item uit de winkelwagen
        /// </summary>
        /// <param name="id">Het id van een CartItem</param>
        /// <returns>Terug naar het overzicht van de winkelwagen wanneer succesvol. Naar de error-page wanneer niet succesvol</returns>
        public ActionResult Delete(int id)
        {
            try
            {
                List<CartItem> cart = GetCartFromSession();
                cart.Remove(cart.First(c => c.Id == id));
            }
            catch(Exception e)
            {
                //TODO: Replace error screen with a little popup message
                return View("Error");
            }
            //Session["cart"] = cart; //Is niet nodig?
            return View("Index");
        }
        
        /// <summary>
        /// Probeert een nieuw item toe te voegen aan de winkelwagen. Als er als een instantie van het item aanwezig is, wordt de qty
        /// opgeteld bij het bestaande item
        /// </summary>
        /// <param name="id">Het id van een CartItem</param>
        /// <param name="quantity">Het aantal reserveringen dat wordt geplaatst (of toegevoegt)</param>
        /// <returns>Terug naar het overzicht van de winkelwagen wanneer succesvol. Naar de error-page wanneer niet succesvol</returns>
        public ActionResult Order(int id, int quantity)
        {
            try
            {
                //Controlleer of er al een winkelwagen is
                if (Session["cart"] == null)
                {
                    List<CartItem> cart = new List<CartItem>();
                    cart.Add(new CartItem(id, quantity));
                    Session["cart"] = cart;
                }
                else
                {
                    List<CartItem> cart = (List<CartItem>) Session["cart"];
                    CartItem ci = cart.FirstOrDefault(c => c.Id == id);
                    //Controlleer of het gegeven item al aanwezig is
                    if (ci == null)
                        cart.Add(new CartItem(id, quantity));
                    else
                        ci.Quantity += quantity;
                    Session["cart"] = cart;
                }
            }
            catch (Exception e)
            {
                return View("Error");
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

        public CartItem GetCartItem(int id)
        {
            List<CartItem> cart = GetCartFromSession();
            return cart.First(c => c.Id == id);
        }

        /// <summary>
        /// Zet de sessionvariabele om in een bruikbare lijst van CartItems
        /// </summary>
        /// <returns>Een lijst van CartItems</returns>
        private List<CartItem> GetCartFromSession()
        {
            return (List<CartItem>)Session["cart"];
        }
        
        /// <summary>
        /// Berekent de totaalprijs van de huidige winkelwagen
        /// </summary>
        /// <returns>De totaalprijs van de winkelwagen</returns>
        private float CalculateCartValue()
        {
            //TODO: Houdt rekening met restaurantreserveringen!

            List<CartItem> cart = (List<CartItem>)Session["cart"];

            float totaal = 0;
            foreach (CartItem item in cart)
                totaal += item.Price * item.Quantity;

            return totaal;
        }
    }
}
