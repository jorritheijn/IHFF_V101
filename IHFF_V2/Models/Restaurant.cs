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
    
    public partial class Restaurant
    {
        public int Id { get; set; }
        public string Soort { get; set; }
        public string OpeningsTijd { get; set; }
        public int EventId { get; set; }
    
        public virtual Event Event { get; set; }
    }
}
