using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Models
{
    public partial class BestelRegel
    {
        public BestelRegel()
        {
            
        }

        public BestelRegel(int bestellingId, int eventId, int quantity)
        {
            BestellingId = bestellingId;
            EventId = eventId;
            Quantity = quantity;
        }
    }
}