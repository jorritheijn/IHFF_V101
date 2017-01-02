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
        public Restaurant GetRestaurant(int Id)
        {

            // return event/restaurant
            throw new NotImplementedException();
        }
    }
}