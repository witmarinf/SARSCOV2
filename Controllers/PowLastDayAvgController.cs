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
    public class PowLastDayAvgController : Controller
    {
        // GET: PowLastDayAvg
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AjaxMethod()
        {
            string query = "SELECT p.powiat_miasto, p.bez, p.z, p.srednia FROM PowLastDayAvg p";

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