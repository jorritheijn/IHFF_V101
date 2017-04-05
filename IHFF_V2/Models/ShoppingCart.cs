using System;
using System.Collections.Generic;
using System.EnterpriseServices;
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

        public void IncrementItemQuantity(int id)
        {
            CartItem ci = GetCartItem(id);
            ci.Quantity++;
        }

        public void DecrementItemQuantity(int id)
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

        public void AddItem(int id, int quantity)
        {
            CartItem ci = cart.FirstOrDefault(c => c.Id == id);

            if (ci == null)
                cart.Add(new CartItem(id, quantity));
            else
                ci.Quantity += quantity;
        }

        public CartItem GetCartItem(int id)
        {
            return cart.First(c => c.Id == id);
        }

        public float CalculateCartValue()
        {
            float total = 0;

            foreach (CartItem ci in cart)
            {
                if (ci.Type == "Restaurant")
                    total += 10;
                else
                    total += (float) ci.Prijs * ci.Quantity;
            }

            return total;
        }

        public List<CartItem> GetCart()
        {
            return cart;
        }
    }
}