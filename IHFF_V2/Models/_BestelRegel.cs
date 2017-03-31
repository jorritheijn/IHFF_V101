using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Models
{
    public partial class BestelRegel
    {
        public BestelRegel(int eventId, int quantity)
        {
            this.EventId = eventId;
            this.Quantity = quantity;
        }
    }
}