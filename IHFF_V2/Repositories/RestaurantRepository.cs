using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;


namespace IHFF_V2.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private ihffContext ctx = new ihffContext();
        public DetailRestaurantViewModel GetSpecificRestaurant(int Id)
        {
            DetailRestaurantViewModel DetailedRestaurantModel = new DetailRestaurantViewModel();

            //get a specific Restaurant with given id from Restaurantoverview
            DetailedRestaurantModel.Event = ctx.Events.SingleOrDefault(a => a.Id == Id);

            //get a specific restaurant with eventid
            DetailedRestaurantModel.Restaurant = ctx.Restaurants.First(a => a.EventId == Id);

            //get time times
            DetailedRestaurantModel.Dagdeel = GetRestaurantdagdeel(DetailedRestaurantModel);

            //get RandomEvent
            DetailedRestaurantModel.RandomEvent = GetRandomEvents();

            //return a model with multiple models within it
            return DetailedRestaurantModel;
        }

        public List<string> GetRestaurantdagdeel(DetailRestaurantViewModel DetailedRestaurantModel)
        {
            IEnumerable<Restaurant> allspecificRestaurants = ctx.Restaurants.Where(b => b.EventId == DetailedRestaurantModel.Event.Id); //get all restaurant times
            List<string> Dagdelen = new List<string>();

            TimeSpan? ochtend = new TimeSpan(11,0,0);
            TimeSpan? middag = new TimeSpan(18, 0, 0);


            foreach (var specificevent in allspecificRestaurants)
            {
                if (specificevent.SluitingsTijd <= middag && specificevent.SluitingsTijd >= ochtend)//add nothing if there is no date
                {
                    string tijd = "Lunch";
                    Dagdelen.Add(tijd);
                }
                else if (specificevent.SluitingsTijd <= ochtend)
                {
                    string tijd = "Ontbijt";
                    Dagdelen.Add(tijd);
                }
                else
                {
                    string tijd = "Dinner";
                    Dagdelen.Add(tijd);
                }
            }
            return Dagdelen;
        }

        //gets three random events from database
        public IEnumerable<Event> GetRandomEvents()
        {
            IEnumerable<Event> RandomEvents = ctx.Events.Where(x => x.Type != "Restaurant").OrderBy(r => Guid.NewGuid()).Take(3);

            return RandomEvents;
        }

        public IEnumerable<Event> AlleRestaurants
        {
            get
            {
                IEnumerable<Event> allerestaurants = ctx.Events.Where(restaurant => restaurant.Type.Equals("Restaurant"));
                return allerestaurants;
            }
        }
    }
}