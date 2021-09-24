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
    public class AbonmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Abonments
        public ActionResult Index()
        {
            var abonments = db.Abonments.Include(a => a.Offre).Include(a => a.user);
            return View(abonments.ToList());
        }

        // GET: Abonments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonments abonments = db.Abonments.Find(id);
            if (abonments == null)
            {
                return HttpNotFound();
            }
            return View(abonments);
        }

        // GET: Abonments/Create
      
        // POST: Abonments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       [Authorize]
        public ActionResult CreateAbon( )
        {
            
                var abon = new Abonments();
                abon.OffreId=(int)Session["offre_id"];

                abon.userId = User.Identity.GetUserId();
                abon.date_Abon = DateTime.Now;
                db.Abonments.Add(abon);
                db.SaveChanges();
                return RedirectToAction("Details","Offres", new { id = (int)Session["offre_id"] });
            }
        [Authorize]
        public ActionResult SuppAbon()
        {

            var AbonId = (int)Session["offre_id"];

            var con = User.Identity.GetUserId();
            var verifAbon = db.Abonments.Where(a => a.OffreId == AbonId && a.userId == con).SingleOrDefault();
            db.Abonments.Remove(verifAbon);
            db.SaveChanges();

            return RedirectToAction("Details", "Offres", new { id = (int)Session["offre_id"] });
        }





        // GET: Abonments/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonments abonments = db.Abonments.Find(id);
            if (abonments == null)
            {
                return HttpNotFound();
            }
            ViewBag.OffreId = new SelectList(db.Offres, "Id", "description", abonments.OffreId);
          
            return View(abonments);
        }

        // POST: Abonments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date_Abon,OffreId,userId")] Abonments abonments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abonments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OffreId = new SelectList(db.Offres, "Id", "description", abonments.OffreId);
          
            return View(abonments);
        }

        // GET: Abonments/Delete/ 
        [Authorize]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonments abonments = db.Abonments.Find(id);
            if (abonments == null)
            {
                return HttpNotFound();
            }
            return View(abonments);
        }

        // POST: Abonments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abonments abonments = db.Abonments.Find(id);
            db.Abonments.Remove(abonments);
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
