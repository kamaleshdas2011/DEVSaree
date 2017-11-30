using DataModel;
using kd_aspmvc.AdminHelper;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace kd_aspmvc.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        ImageStore _store = new ImageStore();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Upload(HttpPostedFileBase stream, string name)
        {
            if (stream!=null)
            {
                var id = await _store.SaveImage(stream.InputStream, name);
                return RedirectToAction("Show", new { id = id });
            }
            return View();
        }
        public ActionResult Show(string id)
        {
            var model = new Images { ImageUri = _store.UriFor(id).ToString() };
            return View(model);
        }
        public ActionResult GetAllImages()
        {
            var images = _store.GetAllImages();
            return View(images);
        }
    }
}