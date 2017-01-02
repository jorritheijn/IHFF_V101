using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Models
{
    public class DetailRestaurantViewModel
    {
        public string Titel { get; set; }
        public string Poster { get; set; }
        public string Omschrijving { get; set; }
        public DateTime OpeningsTijd { get; set; }


        public DetailRestaurantViewModel(string Titel, string Poster, string Omschrijving, DateTime OpeningsTijd)
        {
            this.Titel = Titel;
            this.Poster = Poster;
            this.Omschrijving = Omschrijving;
            this.OpeningsTijd = OpeningsTijd;
        }
    }
}