using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System;

namespace SARSCOV2.Controllers
{
    public class WojProcStatController : Controller
    {
        //[Authorize(Roles = "admin, manager, student")]

        public ActionResult Index()
        {
            return View();
        }
        
        //[Authorize(Roles = "admin, manager, student")]

        [HttpPost]
        public JsonResult AjaxMethod(DateTime start, DateTime stop, string x)
        {
            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {
                            "wojewodztwo",
                            "liczba",
                            "suma",
                            "minimum",
                            "maksimum",
                            "srednia",
                            "odchylenie standardowe",
                            "Q1",
                            "Q2",
                            "Q3"
                        });

            using (SqlConnection connection = new SqlConnection(constructor))
            {
                using (SqlCommand cmd = new SqlCommand("woj_stat_report", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = connection;
                    cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = Convert.ToDateTime(start);
                    cmd.Parameters.Add("@stop", SqlDbType.DateTime).Value = Convert.ToDateTime(stop);
                    cmd.Parameters.Add("@x", SqlDbType.NVarChar).Value = x;

                    connection.Open();
                    using (SqlDataReader sql_data_reader = cmd.ExecuteReader())
                    {
                        while (sql_data_reader.Read())
                        {
                            chart_data.Add(new object[]
                        {
                            sql_data_reader["wojewodztwo"].ToString(),
                            sql_data_reader["liczba"],
                            sql_data_reader["suma"],
                            sql_data_reader["minimum"],
                            sql_data_reader["maksimum"],
                            sql_data_reader["srednia"],
                            sql_data_reader["odchylenie_standardowe"],
                            sql_data_reader["Q1"],
                            sql_data_reader["Q2"],
                            sql_data_reader["Q3"],
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
