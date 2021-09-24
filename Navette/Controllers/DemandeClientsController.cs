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
    public class DemandeClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DemandeClients
        public ActionResult Index()
        {
            var demandeClients = db.DemandeClients.Include(d => d.user);
            return View(demandeClients.ToList());
        }

        // GET: DemandeClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemandeClient demandeClient = db.DemandeClients.Find(id);
            if (demandeClient == null)
            {
                return HttpNotFound();
            }
            return View(demandeClient);
        }

        // GET: DemandeClients/Create
        [Authorize]
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: DemandeClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( DemandeClient demandeClient,string depart,string destination,DateTime h_depart, DateTime h_destination)
        {
            if (ModelState.IsValid)
            {
                string h_depart_string = h_depart.ToString("HH:mm");
                string h_destination_string = h_destination.ToString("HH:mm");
                DemandeClient demandeClient1 = db.DemandeClients.Where(a => a.depart.Equals(depart) && a.destination.Equals(destination) && a.h_depart.Equals(h_depart_string) && a.h_destination.Equals(h_destination_string)).FirstOrDefault();
                if (demandeClient1 != null)
                {
                    demandeClient1.num_demande += 1;
                    db.Entry(demandeClient1).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else { 
                demandeClient.num_demande = 1;
                demandeClient.userId= User.Identity.GetUserId();
                db.DemandeClients.Add(demandeClient);
                db.SaveChanges();}
              return RedirectToAction("About", "Home");
            }


              return RedirectToAction("About", "Home");
        }
        public ActionResult CreateAdmin()
        {

            return View();
        }

        // POST: DemandeClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdmin(DemandeClient demandeClient, string depart, string destination, DateTime h_depart, DateTime h_destination)
        {
            if (ModelState.IsValid)
            {
                string h_depart_string = h_depart.ToString("HH:mm");
                string h_destination_string = h_destination.ToString("HH:mm");
                DemandeClient demandeClient1 = db.DemandeClients.Where(a => a.depart.Equals(depart) && a.destination.Equals(destination) && a.h_depart.Equals(h_depart_string) && a.h_destination.Equals(h_destination_string)).FirstOrDefault();
                if (demandeClient1 != null)
                {
                    demandeClient1.num_demande += 1;
                    db.Entry(demandeClient1).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    demandeClient.num_demande = 1;
                    demandeClient.userId = User.Identity.GetUserId();
                    db.DemandeClients.Add(demandeClient);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "DemandeClients");
            }

            return RedirectToAction("Index", "DemandeClients");

        }

        // GET: DemandeClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemandeClient demandeClient = db.DemandeClients.Find(id);
            if (demandeClient == null)
            {
                return HttpNotFound();
            }
           
            return View(demandeClient);
        }

        // POST: DemandeClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,depart,destination,h_depart,h_destination,num_demande,userId")] DemandeClient demandeClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demandeClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            return View(demandeClient);
        }

        // GET: DemandeClients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemandeClient demandeClient = db.DemandeClients.Find(id);
            if (demandeClient == null)
            {
                return HttpNotFound();
            }
            return View(demandeClient);
        }

        // POST: DemandeClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DemandeClient demandeClient = db.DemandeClients.Find(id);
            db.DemandeClients.Remove(demandeClient);
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
