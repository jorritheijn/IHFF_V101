using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Repositories;

namespace IHFF_V2.Models
{
    public class CartItem : Event
    {
        /*
        public int Id { get; set; } //EventId
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public float Price { get; set; } //Per item
        public int Quantity { get; set; }

        public Event Event { get; }
        */

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

        //public CartItem(int id, string name, string location, DateTime time, float price, int quantity)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.Location = location;
        //    this.Time = time;
        //    this.Price = price;
        //    this.Quantity = quantity;
        //}

    }
}