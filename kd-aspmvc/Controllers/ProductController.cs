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
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllProducts()
        {
            var _store = new ImageStore();
            List<Product> prods = new List<Product>();
            using (DatabaseContext db=new DatabaseContext())
            {
                prods = db.Products.ToList();
                db.Configuration.AutoDetectChangesEnabled = false;
            }
            
            return Json(prods, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DisplayProductTemplate()
        {
            return PartialView();
        }
    }
}