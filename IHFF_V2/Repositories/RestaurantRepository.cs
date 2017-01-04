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
        public DetailRestaurantViewModel GetRestaurant(int Id)
        {
            DetailRestaurantViewModel DetailedRestaurantModel = new DetailRestaurantViewModel();

            //get a specific filmevent with given id from filmoverviewe
            DetailedRestaurantModel.Event = ctx.Events.SingleOrDefault(a => a.Id == Id);

            //get a specific film with eventid
            DetailedRestaurantModel.Restaurant = ctx.Restaurants.SingleOrDefault(a => a.EventId == Id);

            //return a model with two models within it
            return DetailedRestaurantModel;
        }
    }
}