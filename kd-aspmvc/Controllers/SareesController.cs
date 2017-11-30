using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
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
            //var images = db.ImageContext.ToList();
            return View(sarees);
        }

        // GET: Sarees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sarees sarees = db.SareeContext.Find(id);
            if (sarees == null)
            {
                return HttpNotFound();
            }
            return View(sarees);
        }

        // GET: Sarees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sarees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Material,Colour")] Sarees sarees)
        {
            if (ModelState.IsValid)
            {
                db.SareeContext.Add(sarees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sarees);
        }

        // GET: Sarees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sarees sarees = db.SareeContext.Find(id);
            if (sarees == null)
            {
                return HttpNotFound();
            }
            return View(sarees);
        }

        // POST: Sarees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Material,Colour")] Sarees sarees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sarees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sarees);
        }

        // GET: Sarees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sarees sarees = db.SareeContext.Find(id);
            if (sarees == null)
            {
                return HttpNotFound();
            }
            return View(sarees);
        }

        // POST: Sarees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sarees sarees = db.SareeContext.Find(id);
            db.SareeContext.Remove(sarees);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
