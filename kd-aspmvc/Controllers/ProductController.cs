using DataModel;
using kd_aspmvc.AdminHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kd_aspmvc.Controllers
{
    public class ProductController : Controller
    {
        ImageStore _store = new ImageStore();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllProducts()
        {
            
            List<Product> prods = new List<Product>();
            using (DatabaseContext db = new DatabaseContext())
            {
                prods = db.Products.ToList();
                db.Configuration.AutoDetectChangesEnabled = false;
                //var images = db.Image.ToList();
                foreach (var prod in prods)
                {
                    prod.PreviewImage.ImageLocation = _store.UriFor(prod.PreviewImage.ImageUri);
                    //string[] allImages = prod.all_image_ids.Split(',');
                    //prod.all_images = (from img in images where allImages.Contains(img.Id.ToString()) select img).ToList();
                    //prod.all_images = prod.all_images.Select(c => { c.ImageLocation = _store.UriFor(c.ImageUri); return c; }).ToList();
                }
                
            }
            
            return Json(prods, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DisplayProductTemplate()
        {
            return PartialView();
        }
        public ActionResult ImageCarousel()
        {
            return PartialView();
        }
        public ActionResult ProductDetails(int sku)
        {
            var prods = new Product();
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                prods = (from prod in db.Products where prod.id == sku select prod).FirstOrDefault();
                prods.PreviewImage.ImageLocation = _store.UriFor(prods.PreviewImage.ImageUri);
                //var images = db.Image.ToList();
                //string[] allImages = prods.all_image_ids.Split(',');
                //prods.all_images = (from img in images where allImages.Contains(img.Id.ToString()) select img).ToList();
                //prods.all_images = prods.all_images.Select(c => { c.ImageLocation = _store.UriFor(c.ImageUri); return c; }).ToList();
            }
            return PartialView(prods);
        }
        //public JsonResult AProductDetails(int sku)
        //{
        //    var prods = new Product();
        //    using (DatabaseContext db = new DatabaseContext())
        //    {
        //        db.Configuration.AutoDetectChangesEnabled = false;
        //        prods = (from prod in db.Products where prod.id == sku select prod).FirstOrDefault();
        //        prods.PreviewImage.ImageLocation = _store.UriFor(prods.PreviewImage.ImageUri);
        //        var images = db.Image.ToList();
        //        string[] allImages = prods.all_image_ids.Split(',');
        //        prods.all_images = (from img in images where allImages.Contains(img.Id.ToString()) select img).ToList();
        //        prods.all_images = prods.all_images.Select(c => { c.ImageLocation = _store.UriFor(c.ImageUri); return c; }).ToList();
        //    }

        //    return Json(prods, JsonRequestBehavior.AllowGet);
        //}
    }
}