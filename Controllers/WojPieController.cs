using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace SARSCOV2.Controllers
{
    public class WojPieController : Controller
    {
        // GET: WojPie
        public ActionResult WojZgony()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod()
        {
            string query = "SELECT wojewodztwo, SUM(zgony) zgony from";
            query += " woj_source group by wojewodztwo order by sum(zgony) DESC";
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
                            sql_data_reader["wojewodztwo"].ToString(), sql_data_reader["zgony"]
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