using SARSCOV2.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SARSCOV2.Controllers
{
    public class PowFilterController : Controller
    {
        private DBEntities db = new DBEntities();
        // GET: PowFilter
        public ActionResult Index()
        {
            return View(db.pow_target.ToList());
        }
        [HttpPost]
        public ActionResult Index(DateTime From, DateTime To)
        {
            return View(db.function_pow_filter_records(From, To));
        }
    }
}