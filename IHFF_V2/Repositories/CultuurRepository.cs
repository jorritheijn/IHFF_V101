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
        public IEnumerable<Event> GetAllCultuurEvents()
        {
           IEnumerable<Event> GetAllCultuurEvents = ctx.Events.Where(e => e.Type == "Cultuur");
           return GetAllCultuurEvents;
        }

        public IEnumerable<Event> GetSingleCultuurEvent(int Id)
        {
            IEnumerable<Event> GetSpecificCultuur = ctx.Events.Where(e => e.Id == Id);
            
            return GetSpecificCultuur;
        }
    }
}