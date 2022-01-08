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
        public class WojFilterDropdawnController : Controller
    {
        // GET: WojFilterDropdawn
        readonly DBEntities db = new DBEntities();       
        public ActionResult Index(string wojewodztwo, string rok, string miesiac)
            {
            
            ViewBag.wojewodztwo = (from r in db.pow_target select r.wojewodztwo).Distinct();
            ViewBag.rok = (from r in db.pow_target select r.stan_rekordu_na.Value.Year.ToString()).Distinct();
            ViewBag.miesiac = (from r in db.pow_target select r.stan_rekordu_na.Value.Month.ToString()).Distinct();

            var model = from r in db.woj_target
                        orderby r.wojewodztwo
                        where r.wojewodztwo==wojewodztwo || wojewodztwo=="" || wojewodztwo==null
                        where r.stan_rekordu_na.Value.Year.ToString() == rok || rok=="" || rok==null
                        where r.stan_rekordu_na.Value.Month.ToString() == miesiac || miesiac=="" || miesiac == null
                        select r;
            return View(model);
            }    
        }
}
