using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;

namespace IHFF_V2.Repositories
{
    interface ICultuurRepository
    {
         IEnumerable<Event> GetAllCultuurEvents();
        Event GetSingleCultuurEvent(int Id);
    }
}