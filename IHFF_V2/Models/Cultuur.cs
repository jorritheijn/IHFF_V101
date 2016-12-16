using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace IHFF_V2.Models
{
    public class Cultuur
    {
        public int Id { get; set; }
        public int Aantal { get; set; }
        public int EventID { get; set; }
    }
}