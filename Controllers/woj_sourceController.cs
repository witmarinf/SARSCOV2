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
    public class woj_sourceController : Controller
    {
        private DBEntities db = new DBEntities();
        [Authorize(Roles = "admin")]
        // GET: woj_source
        public ActionResult Index()
        {
            return View(db.woj_source.ToList());
        }

        // GET: woj_source/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            woj_source woj_source = db.woj_source.Find(id);
            if (woj_source == null)
            {
                return HttpNotFound();
            }
            return View(woj_source);
        }

        // GET: woj_source/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: woj_source/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,wojewodztwo,liczba_przypadkow,liczba_na_10_tys_mieszkancow,zgony,zgony_w_wyniku_covid_bez_chorob_wspolistniejacych,zgony_w_wyniku_covid_i_chorob_wspolistniejacych,liczba_zlecen_poz,liczba_ozdrowiencow,liczba_osob_objetych_kwarantanna,liczba_wykonanych_testow,liczba_testow_z_wynikiem_pozytywnym,liczba_testow_z_wynikiem_negatywnym,liczba_pozostalych_testow,teryt,stan_rekordu_na")] woj_source woj_source)
        {
            if (ModelState.IsValid)
            {
                db.woj_source.Add(woj_source);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(woj_source);
        }

        // GET: woj_source/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            woj_source woj_source = db.woj_source.Find(id);
            if (woj_source == null)
            {
                return HttpNotFound();
            }
            return View(woj_source);
        }

        // POST: woj_source/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,wojewodztwo,liczba_przypadkow,liczba_na_10_tys_mieszkancow,zgony,zgony_w_wyniku_covid_bez_chorob_wspolistniejacych,zgony_w_wyniku_covid_i_chorob_wspolistniejacych,liczba_zlecen_poz,liczba_ozdrowiencow,liczba_osob_objetych_kwarantanna,liczba_wykonanych_testow,liczba_testow_z_wynikiem_pozytywnym,liczba_testow_z_wynikiem_negatywnym,liczba_pozostalych_testow,teryt,stan_rekordu_na")] woj_source woj_source)
        {
            if (ModelState.IsValid)
            {
                db.Entry(woj_source).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(woj_source);
        }

        // GET: woj_source/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            woj_source woj_source = db.woj_source.Find(id);
            if (woj_source == null)
            {
                return HttpNotFound();
            }
            return View(woj_source);
        }

        // POST: woj_source/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            woj_source woj_source = db.woj_source.Find(id);
            db.woj_source.Remove(woj_source);
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
