using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace IHFF_V2.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Locatie { get; set; }
        //poster = afbeelding
        public string Beschrijving { get; set; }
        public string Type { get; set; }
        public DateTime Tijd { get; set; }
        public int Afbeelding { get; set; }
    }
}