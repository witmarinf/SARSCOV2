using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using SARSCOV2.ModelsDB;

namespace SARSCOV2.Controllers
{
    public class PowLastDayAvgController : Controller
    {
        readonly DBEntities db = new DBEntities();
        // GET: PowLastDayAvg

        public ActionResult Index()
        {
            var termin = (from r in db.woj_target
                          select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> stan_rekordu_na = new List<string>();

            foreach (var da in termin)
            {
                stan_rekordu_na.Add(da.Value.ToString("d"));
            }

            ViewBag.stan_rekordu_na = new SelectList(stan_rekordu_na, "stan_rekordu_na");

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(string stan_rekordu_na)
        {
            string query = "SELECT p.powiat_miasto, p.bez, p.z, p.srednia FROM PowLastDayAvg p WHERE stan_rekordu_na = @stan_rekordu_na ";

            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {
                            "miasto",
                            "liczba zgonów w wyniku covid bez chorób wspołistniejacych",
                            "liczba zgonów w wyniku covid i chorób wspołistniejacych",
                            "średni wynik dla województw"
                        });
            using (SqlConnection connection = new SqlConnection(constructor))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@stan_rekordu_na", stan_rekordu_na);
                    connection.Open();
                    using (SqlDataReader sql_data_reader = cmd.ExecuteReader())
                    {
                        while (sql_data_reader.Read())
                        {
                            chart_data.Add(new object[]
                        {
                            sql_data_reader["powiat_miasto"].ToString(),
                            sql_data_reader["bez"],
                            sql_data_reader["z"],
                            sql_data_reader["srednia"],

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