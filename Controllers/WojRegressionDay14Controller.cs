using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace SARSCOV2.Controllers
{
    public class WojRegressionDay14Controller : Controller
    {
        // GET: WojRegressionDay14
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod()
        {
            string query = "select g, h from WojTrendDay14View";
            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {  
                            "zgony w wyniku covid bez chorób współistniejących",
                            "zgony w wyniku covid i chorób współistniejących"
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
                            sql_data_reader["g"],
                            sql_data_reader["h"],
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