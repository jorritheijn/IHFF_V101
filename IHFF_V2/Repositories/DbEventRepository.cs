using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;

namespace IHFF_V2.Repositories
{
    public class DbEventRepository
    {
        private ihffContext ctx = new ihffContext();

        public IEnumerable<Event> GetAllEvents() 
        {
            IEnumerable<Event> allevents = ctx.Events;
            return allevents; 
        }

        public IEnumerable<Event> eventsopnaam(string zoekwoord) 
        {

            IEnumerable<Event> gefitlerd = ctx.Events.Where(s => s.Titel.Contains(zoekwoord));
            return gefitlerd;
        }
    }
}