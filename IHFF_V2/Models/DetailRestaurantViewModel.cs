using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Models
{
    public class DetailRestaurantViewModel
    {
        //A model that combines two models, list and a IEnum for randomevents in one to pass it to one view.
        public Event Event { get; set; }
        public Restaurant Restaurant { get; set; }

        public IEnumerable<DateTime?> Dagdeel { get; set; }

        public IEnumerable<Event> RandomEvent { get; set; } 

        public DetailRestaurantViewModel(Event Event, Restaurant Restaurant, IEnumerable<DateTime?> Dagdeel, IEnumerable<Event> RandomEvent)
        {
            this.Event = Event;
            this.Restaurant = Restaurant;
            this.Dagdeel = Dagdeel;
            this.RandomEvent = RandomEvent;
        }

        public DetailRestaurantViewModel()
        {

        }
    }
}