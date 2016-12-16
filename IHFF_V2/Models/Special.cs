uusing System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace IHFF_V2.Models
{
    public class Special
    {
        public int Id { get; set; }
        public string Spreker { get; set; }
        public int EventId { get; set; }
        //test
    }
}