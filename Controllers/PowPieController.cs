using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace SARSCOV2.Controllers
{
    public class PowPieController : Controller
    {
        // GET: PowPie
        public ActionResult PowZgony()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod()
        {
            string query = "SELECT powiat_miasto, Sum(zgony) zgony from pow_target group by powiat_miasto order by sum(zgony) DESC";
            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {
                            "wojewodztwo", "zgony"
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
                            sql_data_reader["powiat_miasto"].ToString(), sql_data_reader["zgony"]
                        });
                        }
                    }
                    connection.Close();
                }
            }
            return Json(chart_data);
        }

        //PowPie/PowZgonyPorownanie
        /*
        public ActionResult PowZgonyPorownanie()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult AjaxMethodPor()
        {
            string query = "SELECT wojewodztwo,Sum(zgony) zgony, Sum(zgony_w_wyniku_covid_bez_chorob_wspolistniejacych) bez,";
            query += "Sum(zgony_w_wyniku_covid_i_chorob_wspolistniejacych) z from woj_target group by wojewodztwo order by sum(zgony) ASC";
            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {
                            "wojewodztwo","zgony", "[bez 12]","z"
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
                            sql_data_reader["wojewodztwo"].ToString(),sql_data_reader["zgony"] ,sql_data_reader["bez"],sql_data_reader["z"]
                        });
                        }
                    }

                    connection.Close();
                }
            }
            return Json(chart_data);
        }*/
    }
}