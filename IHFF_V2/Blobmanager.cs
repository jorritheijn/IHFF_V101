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
namespace IHFF_V2
{
    public static class Blobmanager
    {
        public static string ImageSource(byte[] blob)
        {
            var base64 = Convert.ToBase64String(blob);
            return String.Format("data:image/gif;base64,{0}", base64);
        }
    }
}