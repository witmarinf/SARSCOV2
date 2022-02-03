using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SARSCOV2.ModelsDB;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SARSCOV2.Controllers
{
    public class StatController : Controller
    {

        public ActionResult Index()
        {
            DataSet ds = new DataSet();

            string constr = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "Select Format(min(w.stan_rekordu_na),'dd/MM/yyyy') minw,"
                             + "Format(max(w.stan_rekordu_na),'dd/MM/yyyy') maxw," 
                             + "Format(min(p.stan_rekordu_na),'dd/MM/yyyy') minp,"
                             + "Format(max(p.stan_rekordu_na),'dd/MM/yyyy') maxp from woj_target w, pow_target p";

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
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
