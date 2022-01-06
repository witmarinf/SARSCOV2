using SARSCOV2.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SARSCOV2.Controllers
{
    public class GetWojRecordsController : Controller
    {
        // GET: GetWojRecords
        public ActionResult Index()
        {
            DBEntities db = new DBEntities();
            return View(db.woj_target.ToList());
        }
        [HttpPost]
        public ActionResult Index(DateTime From, DateTime To)
        {
            DBEntities db = new DBEntities();
            return View(db.GetFunctionRecordsFromWoj_target(From,To));
        }
    }
}