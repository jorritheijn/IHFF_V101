using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Models
{
    public class DetailFilmViewModel
    {
        public string Titel { get; set; }
        public Byte[] Poster { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Tijd { get; set; }
        public string Cast { get; set; }
        public string Director { get; set; }

        //constructor
        public DetailFilmViewModel(string Titel, Byte[] Poster, string Omschrijving, DateTime Tijd, string Cast, string Director)
        {
            this.Titel = Titel;
            this.Poster = Poster;
            this.Omschrijving = Omschrijving;
            this.Tijd = Tijd;
            this.Cast = Cast;
            this.Director = Director;
        }
    }
}