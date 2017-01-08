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
        public List<string> Tijd { get; set; }

        //constructor
        public DetailFilmViewModel(Event Event, Film Film, List<string> Tijd)
        {
            this.Event = Event;
            this.Film = Film;
            this.Tijd = Tijd;
        }

        public DetailFilmViewModel()
        {
        }
    }
}