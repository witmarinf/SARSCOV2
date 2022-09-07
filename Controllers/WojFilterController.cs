using SARSCOV2.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SARSCOV2.Controllers
{
    [Authorize(Roles = "admin, manager, student")]
    public class WojFilterController : Controller
    {
        private DBEntities db = new DBEntities();
        //[Authorize(Roles = "admin, manager, student")]
        //GET: WojFilter
        public ActionResult Index()
        {

            return View(db.woj_target.ToList());
        }
        [HttpPost]
        public ActionResult Index(DateTime From, DateTime To, string wojewodztwo) 
        {
            return View(db.function_woj_filter_records(From, To, wojewodztwo));
        }
    }
}