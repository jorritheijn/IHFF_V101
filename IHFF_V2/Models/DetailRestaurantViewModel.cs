﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Models
{
    public class DetailRestaurantViewModel
    {
        //A model that combines two models in one to pass it to one view.
        public Event Event { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}