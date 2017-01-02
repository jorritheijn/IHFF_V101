using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Models
{
    public class DetailFilmViewModel
    {
        public string Titel { get; set; }
        public string Poster { get; set; }
        public string Omschrijving { get; set; }
        public DateTime OpeningsTijd { get; set; }
        public string Cast { get; set; }
        public string Director { get; set; }


        public DetailFilmViewModel(string Titel, string Poster, string Omschrijving, DateTime OpeningsTijd, string Cast, string Director)
        {
            this.Titel = Titel;
            this.Poster = Poster;
            this.Omschrijving = Omschrijving;
            this.OpeningsTijd = OpeningsTijd;
            this.Cast = Cast;
            this.Director = Director;
        }
    }
}