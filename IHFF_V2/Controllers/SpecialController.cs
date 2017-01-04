using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;
using System.Web.Mvc;
using IHFF_V2.Repositories;

namespace IHFF_V2.Controllers
{
    public class SpecialController : Controller
    {
        //
        // GET: /Special/
        //all actions with films are done via a FilmRepository
        private IspecialRepository SpecialRepository = new SpecialRepository();

        public ActionResult Index(int Id)
        {

            return View();
        }

        public ActionResult DetailSpecialpage(int Id = 3)
        {
            DetailSpecialViewModel SpecialDetail = SpecialRepository.GetSpecial(Id);

            return View(SpecialDetail);
        }

    }
}
