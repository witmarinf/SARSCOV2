using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Linq;
using SARSCOV2.ModelsDB;
using System;


namespace SARSCOV2.Controllers
{
    public class PowZgonyAllController : Controller
    {
        readonly DBEntities db = new DBEntities();
        //[Authorize(Roles = "admin, manager, student")]
        public ActionResult Index()
        {
            var powiat_miasto = (from r in db.miasta select r.miasto).OrderBy(r => r).ToList();
            ViewBag.powiat_miasto = new SelectList(powiat_miasto, "powiat_miasto");

            return View();
        }
        //[Authorize(Roles = "admin, manager, student")]
        [HttpPost]
        public JsonResult AjaxMethod(string powiat_miasto)
        {
            string query = "SELECT stan_rekordu_na , zgony_w_wyniku_covid_bez_chorob_wspolistniejacych, "
                         + " zgony_w_wyniku_covid_i_chorob_wspolistniejacych FROM PowZgonyAllView " 
                         + " WHERE powiat_miasto=@powiat_miasto ";

            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "stan_rekordu_na",
                            "zgony_w_wyniku_covid_bez_chorob_wspolistniejacych",
                            "zgony_w_wyniku_covid_i_chorob_wspolistniejacych",
                        });
            using (SqlConnection connection = new SqlConnection(constructor))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@powiat_miasto", powiat_miasto);
                    connection.Open();
                    using (SqlDataReader sql_data_reader = cmd.ExecuteReader())
                    {
                        while (sql_data_reader.Read())
                        {
                            chart_data.Add(new object[]
                        {
                            sql_data_reader["stan_rekordu_na"],
                            sql_data_reader["zgony_w_wyniku_covid_bez_chorob_wspolistniejacych"],
                            sql_data_reader["zgony_w_wyniku_covid_i_chorob_wspolistniejacych"]
                        });
                        }
                    }
                    connection.Close();
                }
            }
            return Json(chart_data);
        }
    }
}