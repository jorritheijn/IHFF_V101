using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace IHFF_V2.Models
{
    public class HighLight
    {
        public int Id { get; set; }
        public int Slide1 { get; set; }
        public int Slide2 { get; set; }
        public int Slide3 { get; set; }
        public int Slide4 { get; set; }
        public int Slide5 { get; set; }
    }
}