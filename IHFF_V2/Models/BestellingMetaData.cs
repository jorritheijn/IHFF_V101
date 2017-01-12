using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IHFF_V2.Models
{
    [MetadataType(typeof(BestellingMetaData))]
    public partial class Bestelling
    {
    }

    public class BestellingMetaData
    {
        [Required(ErrorMessage = "Dit veld is verplicht")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        public string EmailAdres { get; set; }
    }
}