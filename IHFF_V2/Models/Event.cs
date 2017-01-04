//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IHFF_V2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public Event()
        {
            this.BestelRegels = new HashSet<BestelRegel>();
            this.CombiDeals = new HashSet<CombiDeal>();
            this.CombiDeals1 = new HashSet<CombiDeal>();
            this.Cultuurs = new HashSet<Cultuur>();
            this.Films = new HashSet<Film>();
            this.Restaurants = new HashSet<Restaurant>();
            this.Specials = new HashSet<Special>();
        }
    
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Locatie { get; set; }
        public byte[] Poster { get; set; }
        public string Beschrijving { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> Tijd { get; set; }
        public Nullable<int> Afbeelding { get; set; }
        public Nullable<double> Prijs { get; set; }
    
        public virtual Afbeelding Afbeelding1 { get; set; }
        public virtual ICollection<BestelRegel> BestelRegels { get; set; }
        public virtual ICollection<CombiDeal> CombiDeals { get; set; }
        public virtual ICollection<CombiDeal> CombiDeals1 { get; set; }
        public virtual ICollection<Cultuur> Cultuurs { get; set; }
        public virtual ICollection<Film> Films { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
        public virtual ICollection<Special> Specials { get; set; }
    }
}
