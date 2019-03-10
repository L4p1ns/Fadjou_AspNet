using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fadiou.Models;
using PagedList;

namespace Fadiou.Controllers
{
    public class MedcinController : Controller
    {
        private bdFadiouContext db = new bdFadiouContext();

        // GET: Medcin
        public ActionResult Index(int? page)
        {
            page = page.HasValue ? page : 1;
            int sizePage = 2;
            int pageNumber = (page ?? 1);
            var lesMedecins = getListMedecin().ToList();
            return View(lesMedecins.ToPagedList(sizePage, pageNumber));
            //return View(getListMedecin().ToList());
        }

        // GET: Medcin/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MedcinViewModel medcinViewModel = db.MedcinViewModels.Find(id);
        //    if (medcinViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(medcinViewModel);
        //}

        // GET: Medcin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medcin/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPers,nomPers,prenomPers,adressePers,dateNaissancePers,sexePers,cniPers,situationMatPers,emailPers,telPers,specialteMed")] MedcinViewModel medcinViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.MedcinViewModels.Add(medcinViewModel);
                Personne p = new Personne();
                p.adressePers = medcinViewModel.adressePers;
                p.cniPers = medcinViewModel.cniPers;
                p.dateNaissancePers = medcinViewModel.dateNaissancePers;
                p.emailPers = medcinViewModel.emailPers;
                p.nomPers = medcinViewModel.nomPers;
                p.prenomPers = medcinViewModel.prenomPers;
                p.sexePers = medcinViewModel.sexePers;
                p.situationMatPers = medcinViewModel.situationMatPers;
                p.telPers = medcinViewModel.telPers;
                db.personnes.Add(p);
                db.SaveChanges();
                Medecin m = new Medecin();
                m.idMed = p.idPers;
                m.specialteMed = medcinViewModel.specialteMed;
                //m.personne = p;
                db.medecins.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medcinViewModel);
        }

        // GET: Medcin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedcinViewModel medcinViewModel = getListMedecin().Where(a => a.idPers == id).FirstOrDefault();
            if (medcinViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medcinViewModel);
        }

        // POST: Medcin/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPers,nomPers,prenomPers,adressePers,dateNaissancePers,sexePers,cniPers,situationMatPers,emailPers,telPers,specialteMed")] MedcinViewModel medcinViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(medcinViewModel).State = EntityState.Modified;
                //db.SaveChanges();
                Personne p = db.personnes.Find(medcinViewModel.idPers);
                p.adressePers = medcinViewModel.adressePers;
                p.cniPers = medcinViewModel.cniPers;
                p.dateNaissancePers = medcinViewModel.dateNaissancePers;
                p.emailPers = medcinViewModel.emailPers;
                p.nomPers = medcinViewModel.nomPers;
                p.prenomPers = medcinViewModel.prenomPers;
                p.sexePers = medcinViewModel.sexePers;
                p.situationMatPers = medcinViewModel.situationMatPers;
                p.telPers = medcinViewModel.telPers;
                // db.personnes.Add(p); //pas besoin de faire un add 
                db.SaveChanges();
                Medecin m = db.medecins.Find(medcinViewModel.idPers);
                m.specialteMed = medcinViewModel.specialteMed;
                //m.personne = p;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medcinViewModel);
        }

        // GET: Medcin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedcinViewModel medcinViewModel = getListMedecin().Where(a => a.idPers == id).FirstOrDefault();
            if (medcinViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medcinViewModel);
        }

        // POST: Medcin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //MedcinViewModel medcinViewModel = db.MedcinViewModels.Find(id);
            //db.MedcinViewModels.Remove(medcinViewModel);
            //db.SaveChanges();
            // Delete Medecin First
            Medecin m = db.medecins.Find(id);
            db.medecins.Remove(m);
            db.SaveChanges();
            Personne p = db.personnes.Find(id);
            db.personnes.Remove(p);
            db.SaveChanges();
           
            return RedirectToAction("Index");
        }

        public ActionResult listeDesPersonnes()
        {
            return View(db.personnes.ToList());
        }

        public ActionResult listdesMedecins()
        {
            return View(db.medecins.Include(a => a.personne).ToList());
        }

        public List<MedcinViewModel> getListMedecin()
        {
            var listPersonne = db.medecins.ToList();
            List<MedcinViewModel> lesMedecins = new List<MedcinViewModel>();
            foreach(var x in listPersonne)
            {
                MedcinViewModel m = new MedcinViewModel();
                var i = db.personnes.Find(x.idMed);
                m.idPers = i.idPers;
                m.nomPers = i.nomPers;
                m.adressePers = i.adressePers;
                m.cniPers = i.cniPers;
                m.dateNaissancePers = i.dateNaissancePers;
                m.emailPers = i.emailPers;
                m.prenomPers = i.prenomPers;
                m.sexePers = i.sexePers;
                m.situationMatPers = i.situationMatPers;
                m.specialteMed = x.specialteMed;
                m.telPers = i.telPers;
                lesMedecins.Add(m);
            }
            return lesMedecins;
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
