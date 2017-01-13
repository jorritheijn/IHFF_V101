using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;
using System.Web.Mvc;
using System.Data.Entity;
using IHFF_V2.Repositories;
using System.Web.UI;

namespace IHFF_V2.Repositories
{
    public class PictureRepository
    {
        private ihffContext ctx = new ihffContext();

        public void AddPicture(byte[] imageData, int Id)
        {
            Event WaarHetPlaatjeMoet = ctx.Events.SingleOrDefault(E => E.Id == Id);
            WaarHetPlaatjeMoet.Poster = imageData;
            ctx.Entry(WaarHetPlaatjeMoet).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}