using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;

namespace IHFF_V2.Repositories
{
    public class EventRepository
    {
        private ihffContext ctx;

        public EventRepository()
        {
            ctx = new ihffContext();
        }

        public Event GetEvent(int id)
        {
            return ctx.Events.First(e => e.Id == id);
        }
    }
}