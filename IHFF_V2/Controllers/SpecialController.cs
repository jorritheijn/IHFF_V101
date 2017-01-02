using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;
using System.Web.Mvc;

namespace IHFF_V2.Controllers
{
    public class SpecialController : Controller
    {
        //
        // GET: /Special/

        public ActionResult Index(int Id)
        {

            return View();
        }

        public ActionResult detailpage()
        {
            // laad Special
            //IEnumerable<DetailSpecialViewModel> Special = 

            return View();
        }

    }
}
