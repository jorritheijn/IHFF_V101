﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Models
{
    public class DetailFilmViewModel
    {
        //A model that combines two models in one to pass it to one view.
        public Event Event { get; set; }
        public Film Film { get; set; }



       /* public string Titel { get; set; }
        public Byte[] Poster { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Tijd { get; set; }
        public string Cast { get; set; }
        public string Director { get; set; }
        */

        //constructor
        public DetailFilmViewModel(Event Event, Film Film)
        {
            this.Event = Event;
            this.Film = Film;
        }

        public DetailFilmViewModel()
        {
        }
    }
}