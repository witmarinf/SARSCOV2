using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SARSCOV2.Controllers
{
    public class TablePowLastDayController : Controller
    {    //[Authorize(Roles = "admin, manager, student")]
        // GET: TablePowLastDay
        public ActionResult Index()
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                string query = "SELECT x,b,c,d,e,f,g,h,i,j,k,l FROM TablePowLastDay";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }
            return View(ds);
        }
    }
}