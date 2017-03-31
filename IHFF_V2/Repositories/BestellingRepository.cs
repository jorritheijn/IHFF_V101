using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;

namespace IHFF_V2.Repositories
{
    public class BestellingRepository
    {
        private BestellingContext ctx;

        public BestellingRepository()
        {
            ctx = new BestellingContext();
        }

        public void CreateOrder(List<CartItem> cart, Bestelling bestelling)
        {
            AddGeneratedCodeToBestelling(4, bestelling);
            AddCartItemsToBestelling(cart, bestelling);
            AddOrderToDb(bestelling);
        }

        /// <summary>
        /// Voegt het bestelling object toe aan de database, inclusief BestelRegels
        /// </summary>
        /// <param name="bestelling">De bestelling die in de database wordt gezet</param>
        private void AddOrderToDb(Bestelling bestelling)
        {
            ctx.Bestellingen.Add(bestelling);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Voegt de items in de cart toe aan de bestelling als BestelRegels
        /// </summary>
        /// <param name="cart">Een lijst van items om te bestellen</param>
        /// <param name="bestelling">De bestelling waar de items aan toegevoegt worden</param>
        private void AddCartItemsToBestelling(List<CartItem> cart, Bestelling bestelling)
        {
            foreach (CartItem item in cart)
                bestelling.BestelRegels.Add(new BestelRegel(item.Id, item.Quantity));
        }

        /// <summary>
        /// Pakt een gegeven hoeveelheid random chars uit een string en voegt dit toe aan bestelling als de code
        /// </summary>
        /// <param name="length">Lengte van de code</param>
        /// <param name="bestelling">De bestelling waar de code aan toegevoegt wordt</param>
        private void AddGeneratedCodeToBestelling(int length, Bestelling bestelling)
        {
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            bestelling.Code = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}