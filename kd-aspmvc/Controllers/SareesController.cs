using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DataModel;
using kd_aspmvc.AdminHelper;

namespace kd_aspmvc.Controllers
{
    public class SareesController : Controller
    {
        private SareeDbContext db = new SareeDbContext();
        private ImageStore _store = new ImageStore();
        // GET: Sarees
        public ActionResult Index()
        {
            var sarees = db.SareeContext.Include(m=>m.Image).ToList();
            db.Configuration.AutoDetectChangesEnabled = false;
            foreach (var saree in sarees)
            {
                saree.Image.ImageUri = _store.UriFor(saree.Image.ImageUri).ToString();
            }
            return View(sarees);
        }
        
        
        // GET: Sarees/Create
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult GetCreateData()
        {
            var materials = db.Material.ToList();
            var colours = db.Colours.ToList();
            return Json(new { Materials = materials, Colours = colours }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaterialId,ColourId,ImageId")] Sarees sarees)
        {
            if (ModelState.IsValid)
            {
                db.SareeContext.Add(sarees);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }        
    }
}
