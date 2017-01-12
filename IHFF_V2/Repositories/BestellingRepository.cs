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
            //Formulier moet een Bestelling object aanmaken en meegeven

            //Maak nieuwe bestelling aan
            //Pak de ID
            //Gebruik de ID om de BestelRegels aan te maken
        }

        //Gooi de bestelling in de database en geef 't ID terug
        private int MaakBestelling(Bestelling bestelling)
        {
            ctx.Bestellingen.Add(bestelling);
            ctx.SaveChanges();

            return bestelling.Id;
        }

        //Gooi de items een voor een in de database
        private void MaakBestelRegels(List<CartItem> cart, int id)
        {
            foreach (CartItem item in cart)
            {
                BestelRegel bestelRegel = new BestelRegel(id, item.Id, item.Quantity);

                ctx.BestelRegels.Add(bestelRegel);
                ctx.SaveChanges();
            }
        }

        //Generate a (default) 4 char code
        private string GenerateCode(int length = 4)
        {
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}