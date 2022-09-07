using SARSCOV2.ModelsDB;
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
    public class TableWojLastDayController : Controller
    {   
        
        //[Authorize(Roles = "admin, manager, student")]
        // GET: TableWojLastDay
        public ActionResult Index()
        {
            DBEntities db = new DBEntities();

           /*
            var termin = (from r in db.woj_target
                          select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> stan_rekordu_na = new List<string>();

            foreach (var da in termin)
            {
                stan_rekordu_na.Add(da.Value.ToString("d"));
            }
            ViewBag.stan_rekordu_na = new SelectList(stan_rekordu_na, "stan_rekordu_na");
           */



            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                string query = "SELECT x,b,c,d,e,f,g,h,i,j,k,l FROM PolandMapLastDayView"; // WHERE stan_rekordu_na=@stan_rekordu_na";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
             //       cmd.Parameters.AddWithValue("@stan_rekordu_na", stan_rekordu_na);
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
