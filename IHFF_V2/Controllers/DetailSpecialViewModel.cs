using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Models
{
    public class DetailSpecialViewModel
    {
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        public DateTime OpeningsTijd { get; set; }
        public string Lezer { get; set; }


        public DetailSpecialViewModel(string Titel, string Omschrijving, DateTime OpeningsTijd, string Lezer)
        {
            this.Titel = Titel;
            this.Omschrijving = Omschrijving;
            this.OpeningsTijd = OpeningsTijd;
            this.Lezer = Lezer;
        }

    }
}