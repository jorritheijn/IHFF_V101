using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;

namespace IHFF_V2.Repositories
{
    public class CultuurRepository : ICultuurRepository
    {
        private ihffContext ctx = new ihffContext();
        public IEnumerable<Event> GetAllCultuurEvents() //tabel cultuur gebruiken
        {
           IEnumerable<Event> GetAllCultuurEvents = ctx.Events.Where(e => e.Type == "Cultuur");
           return GetAllCultuurEvents;
        }

        public Event GetSingleCultuurEvent(int Id) //cultuur tabel gebruiken indien mogelijk 
        {
            Event GetSpecificCultuur = ctx.Events.Where(e => e.Id == Id).SingleOrDefault();

            return GetSpecificCultuur;
        }
    }
}