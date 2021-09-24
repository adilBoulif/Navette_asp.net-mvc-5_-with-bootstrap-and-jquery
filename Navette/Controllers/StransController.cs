using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Navette.Models;
using System.IO;

namespace Navette.Controllers
{
    public class StransController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Strans
        public ActionResult Index()
        {
            return View(db.Strans.ToList());
        }

        // GET: Strans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strans strans = db.Strans.Find(id);
            if (strans == null)
            {
                return HttpNotFound();
            }
            return View(strans);
        }

        // GET: Strans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Strans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Strans strans ,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                strans.image = upload.FileName;

                db.Strans.Add(strans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(strans);
        }

        // GET: Strans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strans strans = db.Strans.Find(id);
            if (strans == null)
            {
                return HttpNotFound();
            }
            return View(strans);
        }

        // POST: Strans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Strans strans ,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                strans.image = upload.FileName;
                }
               
                db.Entry(strans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(strans);
        }

        // GET: Strans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strans strans = db.Strans.Find(id);
            if (strans == null)
            {
                return HttpNotFound();
            }
            return View(strans);
        }

        // POST: Strans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Strans strans = db.Strans.Find(id);
            db.Strans.Remove(strans);
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
