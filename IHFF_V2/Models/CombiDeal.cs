using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace IHFF_V2.Models
{
    public class CombiDeal
    {
        public int Id { get; set; }
        public int Percentage { get; set; }
        public int Event2 { get; set; }
        public int Event1 { get; set; }
    }
}