using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Models
{
    public class ShoppingCart
    {
        private List<CartItem> cart;

        public ShoppingCart()
        {
            cart = new List<CartItem>();
        }

        public void IncrementQuantity(int id)
        {
            CartItem ci = GetCartItem(id);
            ci.Quantity++;
        }

        public void DecrementQuantity(int id)
        {
            CartItem ci = GetCartItem(id);
            if (ci.Quantity > 1)
                ci.Quantity--;
            else
            {
                RemoveItem(id);
            }
        }

        public void RemoveItem(int id)
        {
            cart.Remove(GetCartItem(id));
        }

        public void Order(int id, int qty)
        {
            CartItem ci = cart.FirstOrDefault(c => c.Id == id);

            if (ci == null)
                cart.Add(new CartItem(id, qty));
            else
                ci.Quantity += qty;
        }

        public CartItem GetCartItem(int id)
        {
            return cart.First(c => c.Id == id);
        }
    }
}