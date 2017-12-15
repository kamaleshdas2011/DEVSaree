using DataModel;
using kd_aspmvc.AdminHelper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace kd_aspmvc.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        ImageStore _store = new ImageStore();
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost, ValidateAntiForgeryToken]
        //public ActionResult Upload(HttpPostedFileBase stream, string name)
        //{
        //    if (stream != null)
        //    {
        //        var id = _store.SaveImage(stream.InputStream);
        //        return RedirectToAction("Show", new { id = id });
        //    }
        //    return View();
        //}
        //public ActionResult Show(string id)
        //{
        //    var model = new Images { ImageUri = _store.UriFor(id).ToString() };
        //    return View(model);
        //}
        public JsonResult GetAllImages()
        {
            var images = _store.GetAllImages();
            return Json(images, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllBlobImages()
        {
            var images = _store.GetAllBlobImages();
            return Json(images, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ModalImage()
        {
            return PartialView();
        }
        public JsonResult GetImagesByProduct(int sku)
        {
            var prods = new Product();
            List<Images> images = new List<Images>();
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                images = (from img in db.Image
                              join prod in db.Products
                              on img.Id equals prod.id
                              select new { BaseColour = img.BaseColour, Caption = img.Caption, Id = img.Id, ImageUri = img.ImageUri, Name = img.Name } )
                              .ToList().Select(img=> new Images { BaseColour = img.BaseColour, Caption = img.Caption, Id = img.Id, ImageUri = img.ImageUri, Name = img.Name }).ToList();

                images= images.Select(c => { c.ImageLocation = _store.UriFor(c.ImageUri); return c; }).ToList();
                //prods = (from prod in db.Products where prod.id == sku select prod).FirstOrDefault();
                //prods.PreviewImage.ImageLocation = _store.UriFor(prods.PreviewImage.ImageUri);
                //var images = db.Image.ToList();
                //string[] allImages = prods.all_image_ids.Split(',');
                //prods.all_images = (from img in images where allImages.Contains(img.Id.ToString()) select img).ToList();
                //prods.all_images = prods.all_images.Select(c => { c.ImageLocation = _store.UriFor(c.ImageUri); return c; }).ToList();
            }
            return Json(images,JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditBlock()
        {
            return PartialView();
        }


    }
}