using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;


namespace IHFF_V2.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Regisseur { get; set; }
        public string Acteur { get; set; }
        public int Jaar { get; set; }
        public int Aantal { get; set; }
        public int EventId { get; set; }
    }
}