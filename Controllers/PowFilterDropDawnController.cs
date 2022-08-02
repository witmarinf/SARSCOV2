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
    public class PowFilterDropdawnController : Controller
    {
        // GET: PowFilterDropdawn
        readonly DBEntities db = new DBEntities();
        public ActionResult Index(string miasto, string rok, string miesiac)
        {
            ViewBag.miasto = (from r in db.miasta select r.miasto).OrderBy(r=>r);
            ViewBag.rok = (from r in db.pow_target select r.stan_rekordu_na.Value.Year).Distinct().OrderBy(r=>r);
            ViewBag.miesiac = (from r in db.pow_target select r.stan_rekordu_na.Value.Month).Distinct().OrderBy(r=>r);

            var model = from r in db.pow_target
                        orderby r.powiat_miasto
                        where r.powiat_miasto == miasto || miasto == "" || miasto == null
                        where r.stan_rekordu_na.Value.Year.ToString() == rok || rok == "" || rok == null
                        where r.stan_rekordu_na.Value.Month.ToString() == miesiac || miesiac == "" || miesiac == null
                        select r;
            return View(model);
        }
    }
}
