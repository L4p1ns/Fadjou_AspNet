using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fadiou.Models;

namespace Fadiou.Controllers
{
    public class LitsController : Controller
    {
        private bdFadiouContext db = new bdFadiouContext();

        // GET: Lits
        public ActionResult Index()
        {
            
            var lits = db.lits.Include(l => l.Chambre);
            return View(lits.ToList());
        }

        // GET: Lits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lit lit = db.lits.Find(id);
            if (lit == null)
            {
                return HttpNotFound();
            }
            return View(lit);
        }

        // GET: Lits/Create
        public ActionResult Create()
        {
            ViewBag.Chambre = db.chambres.ToList();
            //ViewBag.idChambre = new SelectList(db.chambres, "idCh", "codeCh");
            return View();
        }

        // POST: Lits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLit,codeLit,idChambre")] Lit lit)
        {
            if (ModelState.IsValid)
            {
                db.lits.Add(lit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idChambre = new SelectList(db.chambres, "idCh", "codeCh", lit.idChambre);
            return View(lit);
        }

        // GET: Lits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lit lit = db.lits.Find(id);
            if (lit == null)
            {
                return HttpNotFound();
            }
            ViewBag.idChambre = new SelectList(db.chambres, "idCh", "codeCh", lit.idChambre);
            return View(lit);
        }

        // POST: Lits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLit,codeLit,idChambre")] Lit lit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idChambre = new SelectList(db.chambres, "idCh", "codeCh", lit.idChambre);
            return View(lit);
        }

        // GET: Lits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lit lit = db.lits.Find(id);
            if (lit == null)
            {
                return HttpNotFound();
            }
            return View(lit);
        }

        // POST: Lits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lit lit = db.lits.Find(id);
            db.lits.Remove(lit);
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
