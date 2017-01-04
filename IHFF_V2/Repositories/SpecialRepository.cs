using IHFF_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Repositories
{
    public class SpecialRepository : IspecialRepository
    {
        private ihffContext ctx = new ihffContext();
        public DetailSpecialViewModel GetSpecial(int Id)
        {
            DetailSpecialViewModel DetailedSpecialModel = new DetailSpecialViewModel();

            //get a specific filmevent with given id from filmoverviewe
            DetailedSpecialModel.Event = ctx.Events.SingleOrDefault(a => a.Id == Id);

            //get a specific film with eventid
            DetailedSpecialModel.Special = ctx.Specials.SingleOrDefault(a => a.EventId == Id);

            //return a model with two models within it
            return DetailedSpecialModel;
        }
    }
}