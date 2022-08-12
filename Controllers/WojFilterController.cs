using SARSCOV2.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SARSCOV2.Controllers
{
    public class WojFilterController : Controller
    {
        private DBEntities db = new DBEntities();
        // GET: WojFilter
        public ActionResult Index()
        {
            //List<DateTime?> From1 = (from r in db.woj_target select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            //List<string> From = new List<string>();
            //foreach(DateTime? item in From1){
            //  From.Add(Convert.ToDateTime(item).ToString("dd.MM.yyyy"));
            // }
            //ViewBag.From = new SelectList(From, "From");
            //string createddate = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd h:mm tt");
            //DateTime dt = DateTime.ParseExact(createddate, "yyyy-MM-dd h:mm tt", CultureInfo.InvariantCulture);
            // var To = (from r in db.woj_target select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            //ViewBag.To = new SelectList(To, "To");
            /*
            List<DateTime?> To1 = (from r in db.woj_target select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> To = new List<string>();
            foreach (DateTime? item in To1)
            {
                To.Add(Convert.ToDateTime(item).ToString("dd.MM.yyyy"));
            }
            ViewBag.From = new SelectList(To, "To");
            */
            //List<SelectListItem> wojewodztwo = (List<SelectListItem>)(from r in db.woj_target select r.wojewodztwo).Distinct().OrderBy(r => r);
            //ViewData["wojewodztwo"] = wojewodztwo;
            //ViewBag.wojewodztwo = new SelectList(wojewodztwo, "wojewodztwo"); 
            ViewBag.wojewodztwo = (from r in db.woj_target select r.wojewodztwo).Distinct().OrderBy(r => r);

            return View(db.woj_target.ToList());
        }
        [HttpPost]
        public ActionResult Index(DateTime From, DateTime To, string wojewodztwo) 
        {
            return View(db.function_woj_filter_records(From, To, wojewodztwo));
        }

    }
}