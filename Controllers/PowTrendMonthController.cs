using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;


namespace SARSCOV2.Controllers
{
    public class PowTrendMonthController : Controller
    {
        //GET: Pie 
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod()
        {
            string query = "Select c,f,g from PowTrendMonthView";


            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {
                            "c",
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
                            sql_data_reader["c"].ToString(),
                            sql_data_reader["f"],
                            sql_data_reader["g"]
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