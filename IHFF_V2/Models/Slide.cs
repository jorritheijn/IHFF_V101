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
    
    public partial class Slide
    {
        public Slide()
        {
            this.Highlights = new HashSet<Highlight>();
            this.Highlights1 = new HashSet<Highlight>();
            this.Highlights2 = new HashSet<Highlight>();
            this.Highlights3 = new HashSet<Highlight>();
        }
    
        public int Id { get; set; }
        public string Beschrijving { get; set; }
        public byte[] Afbeelding { get; set; }
        public string ButtonTekst { get; set; }
        public string Link { get; set; }
    
        public virtual Highlight Highlight { get; set; }
        public virtual ICollection<Highlight> Highlights { get; set; }
        public virtual ICollection<Highlight> Highlights1 { get; set; }
        public virtual ICollection<Highlight> Highlights2 { get; set; }
        public virtual ICollection<Highlight> Highlights3 { get; set; }
    }
}
