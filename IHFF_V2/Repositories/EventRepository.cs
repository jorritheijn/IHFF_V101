using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;
using System.Data;

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
        public Event GetCorrectEventForCart(int id, DateTime? tijd) {

            string titel = ctx.Events.Where(a => a.Id == id).Select(a => a.Titel).SingleOrDefault();

            return ctx.Events.Where(a => a.Titel == titel && a.Tijd == tijd).SingleOrDefault();
        }
        public IEnumerable<Event> GetAllEvents()
        {
            IEnumerable<Event> films = ctx.Events.Where(film => film.Type.Equals("Film")).GroupBy(x => x.Titel).Select(x => x.FirstOrDefault());
            IEnumerable<Event> restaurants = ctx.Events.Where(restaurant => restaurant.Type.Equals("Restaurant"));
            IEnumerable<Event> cultuurevents = ctx.Events.Where(cultuurevent => cultuurevent.Type.Equals("Cultuur"));
            IEnumerable<Event> specials = ctx.Events.Where(special => special.Type.Equals("Special"));
            IEnumerable<Event> events = films.Concat(restaurants).Concat(cultuurevents).Concat(specials);
            return events;
        }
        //Haalt events op van het type dat is meegeven in de parameter. Haalt niet meer dan een event op met dezelde titel.
        public IEnumerable<Event> GetEventsOfType(string type)
        {
                    return ctx.Events.Where(film => film.Type.Equals(type)).GroupBy(x => x.Titel).Select(x => x.FirstOrDefault());
        }
        //Haalt alle events op van het type dat is meegegeven in de parameter.
        public IEnumerable<Event> GetAllEventsOfType(string type)
        {
            return ctx.Events.Where(film => film.Type.Equals(type));
        }
        public IEnumerable<Event> KrijgEvents() 
        {
            return ctx.Events;
        }
        public void AddEvent(Event eventItem)
        {
            ctx.Events.Add(eventItem);
            ctx.SaveChanges();
        }
        public void DeleteEvent(int id)
        {           
            Event eventItem = new Event();
            eventItem = ctx.Events.Find(id);
            ctx.Events.Remove(eventItem);
            ctx.SaveChanges();
        }
        public void EditEvent(Event eventItem)
        {
            ctx.Entry(eventItem).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}