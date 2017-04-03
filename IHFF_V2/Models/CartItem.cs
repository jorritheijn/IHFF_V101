using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Repositories;

namespace IHFF_V2.Models
{
    public class CartItem : Event
    {
        public int Quantity { get; set; }

        public CartItem()
        { }

        public CartItem(int id, int quantity)
        {
            Event e = new EventRepository().GetEvent(id);
            
            this.Quantity = quantity;

            this.Id = e.Id;
            this.Titel = e.Titel;
            this.Locatie = e.Locatie;
            this.Poster = e.Poster;
            this.Beschrijving = e.Beschrijving;
            this.Type = e.Type;
            this.Tijd = e.Tijd;
            this.Prijs = e.Prijs;
        }

        public CartItem(Event e, int quantity)
        {
            this.Quantity = quantity;

            this.Id = e.Id;
            this.Titel = e.Titel;
            this.Locatie = e.Locatie;
            this.Poster = e.Poster;
            this.Beschrijving = e.Beschrijving;
            this.Type = e.Type;
            this.Tijd = e.Tijd;
            this.Prijs = e.Prijs;
        }
    }
}