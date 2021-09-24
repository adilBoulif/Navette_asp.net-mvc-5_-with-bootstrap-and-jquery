using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Navette.Models;
namespace Navette.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var offres = db.Offres.Include(o => o.strans);
            return View(offres.ToList());
        }
        public ActionResult Search()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Search(string depart, string destina)
        {
            var resultat = db.Offres.Where(a => a.destination.Equals(destina) && a.depart.Equals(depart) ).ToList();

            return View(resultat);
        }

        public ActionResult About()
        {
            var demandeClients = db.DemandeClients;
            return View(demandeClients.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}