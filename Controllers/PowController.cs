using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SARSCOV2.ModelsDB;

namespace SARSCOV2.Controllers
{
    public class PowController : Controller
    {
        readonly DBEntities db = new DBEntities();

        // GET: Pow
        public ActionResult Index()
        {
            return View(db.pow_target.ToList());
        }

        public ActionResult Raport()
        {
            return View(db.pow_target.ToList());
        }

        // GET: Pow/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pow_target pow_target = db.pow_target.Find(id);
            if (pow_target == null)
            {
                return HttpNotFound();
            }
            return View(pow_target);
        }

        // GET: Pow/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,wojewodztwo,powiat_miasto,liczba_przypadkow,liczba_na_10_tys_mieszkancow,zgony,zgony_w_wyniku_covid_bez_chorob_wspolistniejacych,zgony_w_wyniku_covid_i_chorob_wspolistniejacych,liczba_zlecen_poz,liczba_ozdrowiencow,liczba_osob_objetych_kwarantanna,liczba_wykonanych_testow,liczba_testow_z_wynikiem_pozytywnym,liczba_testow_z_wynikiem_negatywnym,liczba_pozostalych_testow,teryt,stan_rekordu_na")] pow_target pow_target)
        {
            if (ModelState.IsValid)
            {
                db.pow_target.Add(pow_target);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pow_target);
        }

        // GET: Pow/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pow_target pow_target = db.pow_target.Find(id);
            if (pow_target == null)
            {
                return HttpNotFound();
            }
            return View(pow_target);
        }

        // POST: Pow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,wojewodztwo,powiat_miasto,liczba_przypadkow,liczba_na_10_tys_mieszkancow,zgony,zgony_w_wyniku_covid_bez_chorob_wspolistniejacych,zgony_w_wyniku_covid_i_chorob_wspolistniejacych,liczba_zlecen_poz,liczba_ozdrowiencow,liczba_osob_objetych_kwarantanna,liczba_wykonanych_testow,liczba_testow_z_wynikiem_pozytywnym,liczba_testow_z_wynikiem_negatywnym,liczba_pozostalych_testow,teryt,stan_rekordu_na")] pow_target pow_target)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pow_target).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pow_target);
        }

        // GET: Pow/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pow_target pow_target = db.pow_target.Find(id);
            if (pow_target == null)
            {
                return HttpNotFound();
            }
            return View(pow_target);
        }

        // POST: Pow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pow_target pow_target = db.pow_target.Find(id);
            db.pow_target.Remove(pow_target);
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
