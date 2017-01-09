using System;
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

        public List<string> Dagdeel { get; set; }

        public IEnumerable<Event> RandomEvent { get; set; } 

        public DetailRestaurantViewModel(Event Event, Restaurant Restaurant, List<string> Dagdeel, IEnumerable<Event> RandomEvent)
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