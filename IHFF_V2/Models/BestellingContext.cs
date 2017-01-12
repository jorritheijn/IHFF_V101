using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IHFF_V2.Models
{
    public class BestellingContext : DbContext
    {
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<BestelRegel> BestelRegels { get; set; }

        public BestellingContext() : base("ihffCon")
        {

        }
    }
}