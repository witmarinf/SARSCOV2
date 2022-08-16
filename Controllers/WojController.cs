using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SARSCOV2.ModelsDB;

namespace SARSCOV2.Controllers
{
    public class WojController : Controller
    {
        readonly DBEntities db = new DBEntities();

        // GET: Woj
        public ActionResult Index()
        {
            return View(db.woj_target.ToList());
        }

        
        public ActionResult Raport(string wojewodztwo, DateTime? start, DateTime? stop)
        {
            ViewBag.wojewodztwo = new List<string>(from r in db.woj_target select r.wojewodztwo).Distinct().OrderBy(r=>r);
            //ViewBag.start = (from r in db.woj_targetView select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            //ViewBag.stop = (from r in db.woj_targetView select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();

            var model = from r in db.woj_target
                        orderby r.wojewodztwo
                        where r.stan_rekordu_na >=start && r.stan_rekordu_na <= stop
                        where r.wojewodztwo == wojewodztwo || wojewodztwo == "" || wojewodztwo == null
                        select r;

            return View(model);
        }

        public ActionResult RaportWoj(string wojewodztwo, string rok, string miesiac)
        {
            ViewBag.wojewodztwo = new List<string>(from r in db.woj_target select r.wojewodztwo).Distinct().OrderBy(r => r);
            //ViewBag.wojewodztwo = (from r in db.wojewodztwa select r.wojewodztwo).OrderBy(r => r);
            ViewBag.rok = (from r in db.woj_target select r.stan_rekordu_na.Value.Year).Distinct().OrderBy(r => r);
            ViewBag.miesiac = (from r in db.woj_target select r.stan_rekordu_na.Value.Month).Distinct().OrderBy(r => r);


            var model = from r in db.woj_target
                        orderby r.wojewodztwo
                        where r.wojewodztwo == wojewodztwo || wojewodztwo == "" || wojewodztwo == null
                        where r.stan_rekordu_na.Value.Year.ToString() == rok || rok == "" || rok == null
                        where r.stan_rekordu_na.Value.Month.ToString() == miesiac || miesiac == "" || miesiac == null
                        select r;
            return View(model);
        }


        // GET: Woj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            woj_target woj_target = db.woj_target.Find(id);
            if (woj_target == null)
            {
                return HttpNotFound();
            }
            return View(woj_target);
        }

        // GET: Woj/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,wojewodztwo,liczba_przypadkow,liczba_na_10_tys_mieszkancow,zgony,zgony_w_wyniku_covid_bez_chorob_wspolistniejacych,zgony_w_wyniku_covid_i_chorob_wspolistniejacych,liczba_zlecen_poz,liczba_ozdrowiencow,liczba_osob_objetych_kwarantanna,liczba_wykonanych_testow,liczba_testow_z_wynikiem_pozytywnym,liczba_testow_z_wynikiem_negatywnym,liczba_pozostalych_testow,teryt,stan_rekordu_na")] woj_target woj_target)
        {
            if (ModelState.IsValid)
            {
                db.woj_target.Add(woj_target);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(woj_target);
        }

        // GET: Woj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            woj_target woj_target = db.woj_target.Find(id);
            if (woj_target == null)
            {
                return HttpNotFound();
            }
            return View(woj_target);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,wojewodztwo,liczba_przypadkow,liczba_na_10_tys_mieszkancow,zgony,zgony_w_wyniku_covid_bez_chorob_wspolistniejacych,zgony_w_wyniku_covid_i_chorob_wspolistniejacych,liczba_zlecen_poz,liczba_ozdrowiencow,liczba_osob_objetych_kwarantanna,liczba_wykonanych_testow,liczba_testow_z_wynikiem_pozytywnym,liczba_testow_z_wynikiem_negatywnym,liczba_pozostalych_testow,teryt,stan_rekordu_na")] woj_target woj_target)
        {
            if (ModelState.IsValid)
            {
                db.Entry(woj_target).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(woj_target);
        }

        // GET: Woj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            woj_target woj_target = db.woj_target.Find(id);
            if (woj_target == null)
            {
                return HttpNotFound();
            }
            return View(woj_target);
        }

        // POST: Woj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            woj_target woj_target = db.woj_target.Find(id);
            db.woj_target.Remove(woj_target);
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
