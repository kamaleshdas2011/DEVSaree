using DataModel;
using kd_aspmvc.AdminHelper;
using System;
using System.Collections.Generic;
using System.IO;
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
        public JsonResult GetCreateData()
        {
            List<Material> materials = null;
            List<Colours> colours = null;
            List<Product_type> producttype = null;
            using (DatabaseContext db = new DatabaseContext())
            {
                materials = db.Material.ToList();
                colours = db.Colours.ToList();
                producttype = db.Product_type.ToList();
            }

            return Json(new { Materials = materials, Colours = colours, ProductType = producttype }, JsonRequestBehavior.AllowGet);
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
        public ActionResult UploadImage()
        {
            return PartialView();
        }
        [HttpPost]
        public void UploadImages()
        {
            List<Stream> files = new List<Stream>();
            foreach (string filename in Request.Files)
            {
                files.Add(Request.Files[filename].InputStream);
                //HttpPostedFileBase hpf = Request.Files[filename] as HttpPostedFileBase;
                //using (var binaryReader = new BinaryReader(Request.Files[filename].InputStream))
                //{
                //    files.Add(new Files { FileStream = binaryReader.ReadBytes(Request.Files[filename].ContentLength), Name = filename });
                //}

            }
            ImageStore _store = new ImageStore();
            if (files.Count > 0)
            {
                _store.SaveImage(files);
            }
        }
        [HttpPost]
        public void DeleteBlobImage(string blobid)
        {
            //var id = Request.Form["id"];
            Stream stream = null;
            if (Request.Files.Count != 0)
            {
                stream = Request.Files[0].InputStream;
            }

            ImageStore _store = new ImageStore();
            if (blobid != null && stream == null)
            {
                _store.DeleteUpdateBlobImage(blobid, IOActions.Delete.ToString(), null);
            }
            else if (blobid != null && stream != null)
            {
                _store.DeleteUpdateBlobImage(blobid, IOActions.Update.ToString(), stream);
            }
        }
        public ActionResult Product()
        {
            return PartialView();
        }
        public void DeleteProduct(Product prod)
        {
            if (prod != null)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    //newContext.Entry(studentToDelete).State = System.Data.Entity.EntityState.Deleted;
                    var product = (from p in db.Products where p.id == prod.id select p).FirstOrDefault();
                    db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }


        public void AddProduct(Product prod)
        {
            if (prod != null)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    if (prod.id == 0)
                    {
                        db.Products.Add(prod);
                        db.SaveChanges();
                    }
                    else
                    {
                        var product = (from p in db.Products where p.id == prod.id select p).FirstOrDefault();

                        db.Entry(product).CurrentValues.SetValues(prod);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}