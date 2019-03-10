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
    public class InfirmierController : Controller
    {
        private bdFadiouContext db = new bdFadiouContext();

        // GET: Infirmier
        public ActionResult Index(int? page)
        {
            page = page.HasValue ? page : 1;
            int sizePage = 2;
            //int pageNumber = (page ?? 1);
            var lesinfirmiers = getListInfirmiers().ToList();
            return View(lesinfirmiers.ToPagedList((int)page, sizePage));
           // return View(db.personnes.ToList());
        }

        // GET: Infirmier/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    InfirmierViewModel infirmierViewModel = db.InfirmierViewModels.Find(id);
        //    if (infirmierViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(infirmierViewModel);
        //}

        // GET: Infirmier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Infirmier/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPers,nomPers,prenomPers,adressePers,dateNaissancePers,sexePers,cniPers,situationMatPers,emailPers,telPers,specialteInf")] InfirmierViewModel infirmierViewModel)
        {
            if (ModelState.IsValid)
            {
                Personne p = new Personne();
                p.adressePers = infirmierViewModel.adressePers;
                p.cniPers = infirmierViewModel.cniPers;
                p.dateNaissancePers = infirmierViewModel.dateNaissancePers;
                p.emailPers = infirmierViewModel.emailPers;
                p.nomPers = infirmierViewModel.nomPers;
                p.prenomPers = infirmierViewModel.prenomPers;
                p.sexePers = infirmierViewModel.sexePers;
                p.situationMatPers = infirmierViewModel.situationMatPers;
                p.telPers = infirmierViewModel.telPers;
                db.personnes.Add(p);
                db.SaveChanges();
                Infirmier inf = new Infirmier();
                inf.idInf = p.idPers;
                inf.specialteInf = infirmierViewModel.specialteInf;
                db.infirmiers.Add(inf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(infirmierViewModel);
        }

        // GET: Infirmier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            InfirmierViewModel infirmierViewModel = getListInfirmiers().Where(a => a.idPers == id).FirstOrDefault();
            if (infirmierViewModel == null)
            {
                return HttpNotFound();
            }
            return View(infirmierViewModel);
        }

        // POST: Infirmier/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPers,nomPers,prenomPers,adressePers,dateNaissancePers,sexePers,cniPers,situationMatPers,emailPers,telPers,specialteInf")] InfirmierViewModel infirmierViewModel)
        {
            if (ModelState.IsValid)
            {
                Personne p = db.personnes.Find(infirmierViewModel.idPers);
                p.adressePers = infirmierViewModel.adressePers;
                p.cniPers = infirmierViewModel.cniPers;
                p.dateNaissancePers = infirmierViewModel.dateNaissancePers;
                p.emailPers = infirmierViewModel.emailPers;
                p.nomPers = infirmierViewModel.nomPers;
                p.prenomPers = infirmierViewModel.prenomPers;
                p.sexePers = infirmierViewModel.sexePers;
                p.situationMatPers = infirmierViewModel.situationMatPers;
                p.telPers = infirmierViewModel.telPers;
                db.SaveChanges();
                Infirmier inf = db.infirmiers.Find(infirmierViewModel.idPers);
                inf.specialteInf = infirmierViewModel.specialteInf;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(infirmierViewModel);
        }

        // GET: Infirmier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfirmierViewModel infirmierViewModel = getListInfirmiers().Where(a => a.idPers == id).FirstOrDefault();
            if (infirmierViewModel == null)
            {
                return HttpNotFound();
            }
            return View(infirmierViewModel);
        }

        // POST: Infirmier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Infirmier inf = db.infirmiers.Find(id);
            db.infirmiers.Remove(inf);
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
            return View(db.infirmiers.Include(a => a.personne).ToList());
        }

        public List<InfirmierViewModel> getListInfirmiers()
        {
            var listPersonne = db.infirmiers.ToList();
            List<InfirmierViewModel> lesInfirmiers = new List<InfirmierViewModel>();
            foreach (var x in listPersonne)
            {
                InfirmierViewModel inf = new InfirmierViewModel();
                var i = db.personnes.Find(x.idInf);

                inf.idPers = i.idPers;
                inf.nomPers = i.nomPers;
                inf.adressePers = i.adressePers;
                inf.cniPers = i.cniPers;
                inf.dateNaissancePers = i.dateNaissancePers;
                inf.emailPers = i.emailPers;
                inf.prenomPers = i.prenomPers;
                inf.sexePers = i.sexePers;
                inf.situationMatPers = i.situationMatPers;
                inf.specialteInf = x.specialteInf;
                inf.telPers = i.telPers;
                lesInfirmiers.Add(inf);
            }
            return lesInfirmiers;
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
