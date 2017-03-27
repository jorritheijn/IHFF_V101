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
        public IEnumerable<Event> AlleResetaurants
        {
            get
            {
                IEnumerable<Event> allefilms = ctx.Events.Where(film => film.Type.Equals("Restaurant"));
                return allefilms;
            }
        }


        public DetailRestaurantViewModel GetSpecificRestaurant(int Id)
        {
            DetailRestaurantViewModel DetailedRestaurantModel = new DetailRestaurantViewModel();

            try
            {
                //get a specific Restaurant with given id from Restaurantoverview
                DetailedRestaurantModel.Event = ctx.Events.SingleOrDefault(a => a.Id == Id);

                //get a specific restaurant with eventid
                DetailedRestaurantModel.Restaurant = ctx.Restaurants.First(a => a.EventId == Id);

                //get time times
                DetailedRestaurantModel.Dagdeel = GetRestaurantdagdeel(DetailedRestaurantModel);

                //get RandomEvent
                DetailedRestaurantModel.RandomEvent = ctx.Events.Where(x => x.Type != "Restaurant").OrderBy(r => Guid.NewGuid()).Take(3);

                //return a model with multiple models within it
                return DetailedRestaurantModel;
            }
            catch
            {
                return null;
            }

            
        }

        //method that converts all timespans to a list string
        public List<string> GetRestaurantdagdeel(DetailRestaurantViewModel DetailedRestaurantModel)
        {
            IEnumerable<Restaurant> allspecificRestaurants = ctx.Restaurants.Where(b => b.EventId == DetailedRestaurantModel.Event.Id); //get all restaurant times
            List<string> Dagdelen = new List<string>();

            TimeSpan? ochtend = new TimeSpan(11,0,0);
            TimeSpan? middag = new TimeSpan(18, 0, 0);


            foreach (var specificevent in allspecificRestaurants)
            {
                string tijd;

                if (specificevent.SluitingsTijd <= middag && specificevent.SluitingsTijd >= ochtend)//add nothing if there is no date
                {
                    tijd = "Lunch";
                }
                else if (specificevent.SluitingsTijd <= ochtend)
                {
                    tijd = "Ontbijt";
                }
                else
                {
                    tijd = "Dinner";
                }

                Dagdelen.Add(tijd);
            }
            return Dagdelen;
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