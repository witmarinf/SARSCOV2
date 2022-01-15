using SARSCOV2.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SARSCOV2.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
                return View();
        }
    }
}