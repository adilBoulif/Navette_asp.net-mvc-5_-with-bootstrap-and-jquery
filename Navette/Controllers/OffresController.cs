using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Navette.Models;
using Microsoft.AspNet.Identity;

namespace Navette.Controllers
{
    public class OffresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Offres
        public ActionResult Index()
        {
            var offres = db.Offres.Include(o => o.strans);
            return View(offres.ToList());
        }

        // GET: Offres/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offres offres = db.Offres.Find(id);
            if (offres == null)
            {
                return HttpNotFound();
            }
            Session["offre_id"] = id;
            var con = User.Identity.GetUserId();
            var verifAbon = db.Abonments.Where(a => a.OffreId == id && a.userId == con).ToList();
            if (verifAbon.Count >= 1)
            {
                ViewBag.existe = "existe";
            }
            return View(offres);
        }

        // GET: Offres/Create
        public ActionResult Create()
        {
            ViewBag.stransId = new SelectList(db.Strans, "Id", "nom");
            return View();
        }

        // POST: Offres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,description,depart,destination,h_depart,h_retour,place,prix,stransId")] Offres offres)
        {
            if (ModelState.IsValid)
            {
                db.Offres.Add(offres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.stransId = new SelectList(db.Strans, "Id", "nom", offres.stransId);
            return View(offres);
        }

        // GET: Offres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offres offres = db.Offres.Find(id);
            if (offres == null)
            {
                return HttpNotFound();
            }
            ViewBag.stransId = new SelectList(db.Strans, "Id", "nom", offres.stransId);
            return View(offres);
        }

        // POST: Offres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,description,depart,destination,h_depart,h_retour,place,prix,stransId")] Offres offres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.stransId = new SelectList(db.Strans, "Id", "nom", offres.stransId);
            return View(offres);
        }

        // GET: Offres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offres offres = db.Offres.Find(id);
            if (offres == null)
            {
                return HttpNotFound();
            }
            return View(offres);
        }

        // POST: Offres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offres offres = db.Offres.Find(id);
            db.Offres.Remove(offres);
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
