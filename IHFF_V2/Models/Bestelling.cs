using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;


namespace IHFF_V2.Models
{
    public class Bestelling
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Betaald { get; set; }
        public int BestelRegelId { get; set; }
        public int KlantId { get; set; }


    }
}