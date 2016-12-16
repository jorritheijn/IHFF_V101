using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;


namespace IHFF_V2.Models
{
    public class Slide
    {
        public int Id { get; set; }
        public string Beschrijving { get; set; }
        //afbeelding
        public string ButtonText { get; set; }
        public string Link { get; set; }
    }
}