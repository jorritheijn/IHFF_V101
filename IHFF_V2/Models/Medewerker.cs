using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace IHFF_V2.Models
{
    public class Medewerker
    {
        public int Id { get; set; }
        public string GebruikersNaam { get; set; }
        public string Wachtwoord { get; set; }
    }
}