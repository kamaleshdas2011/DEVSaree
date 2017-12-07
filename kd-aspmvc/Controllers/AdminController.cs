using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kd_aspmvc.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Material()
        {
            return PartialView();
        }
        [HttpPost]
        public void AddMaterial(Material material)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Material.Add(material);
                db.SaveChanges();
            }
            //return PartialView();
        }
        public PartialViewResult Colour()
        {
            return PartialView();
        }
        [HttpPost]
        public void AddColour(Colours colour)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Colours.Add(colour);
                db.SaveChanges();
            }
            //return PartialView();
        }
        public PartialViewResult Image()
        {
            return PartialView();
        }
        [HttpPost]
        public void AddImage(Images image)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Image.Add(image);
                db.SaveChanges();
            }
            //return PartialView();
        }
    }
}