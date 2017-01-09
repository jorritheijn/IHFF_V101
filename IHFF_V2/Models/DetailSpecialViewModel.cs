using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Models
{
    public class DetailSpecialViewModel
    {

        //A model that combines two models in one to pass it to one view.
        public Event Event { get; set; }
        public Special Special { get; set; }
        public IEnumerable<Event> RandomEvents { get; set; }

        public DetailSpecialViewModel(Event Event, Special Special, IEnumerable<Event> RandomEvents)
        {
            this.Special = Special;
            this.Event = Event;
            this.RandomEvents = RandomEvents;
        }

        public DetailSpecialViewModel()
        {

        }

    }
}