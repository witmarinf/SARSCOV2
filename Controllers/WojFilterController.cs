using SARSCOV2.ModelsDB;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SARSCOV2.Controllers
{
    public class WojFilterController : Controller
    {
        private DBEntities db = new DBEntities();
        // GET: WojFilter
        public ActionResult Index()
        {

            return View(db.woj_target.ToList());
        }
        [HttpPost]
        public ActionResult Index(DateTime From, DateTime To, string wojewodztwo) 
        {
            return View(db.function_woj_filter_records(From, To, wojewodztwo));
        }

        /*
        [HttpPost]
        public ActionResult StatReport(DateTime Fromdate, DateTime Todate, string x)
        {
            return View(db.woj_stat_report(Fromdate, Todate, x));
        }
        */

    }
}