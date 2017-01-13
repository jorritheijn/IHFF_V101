using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF_V2.Repositories;
using System.IO;

namespace IHFF_V2.Controllers
{
    public class ImageController : Controller
    {
        //
        // GET: /Image/

        public ActionResult AddImage(int Id)
        {
            ViewBag.id = Id;
            ViewBag.Message = "not clicked";
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(int Id, HttpPostedFileBase uploadImages)
        {
            if (uploadImages == null)
            {
                ViewBag.Message = "Selecteer een bestand";
            }

            else if (uploadImages.ContentType != "image/png")
            {
                ViewBag.Message = "Alleen afbeeldingen worden geaccepteerd ";
            }

            else
            {
                PictureRepository pickrepo = new PictureRepository();
                ViewBag.id = Id;
                ViewBag.Message = "clicked";
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadImages.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImages.ContentLength);
                    pickrepo.AddPicture(imageData, Id);
                }
            }
            return View();
        }


    }
}
