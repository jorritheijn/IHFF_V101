using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace IHFF_V2.Models
{
    public class ihffContext : DbContext
    {
        public ihffContext() : base("ihffCon") { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Film> Films { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Special> Specials { get; set; }
        public DbSet<Cultuur> Cultuur { get; set; }
        public DbSet<Medewerker> Medewerker { get; set; }


    }
}