using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Linq;
using SARSCOV2.ModelsDB;


namespace SARSCOV2.Controllers
{
    public class WojTrendDay14Controller : Controller
    {
        readonly DBEntities db = new DBEntities();

        // GET: WojTrendDay14
        public ActionResult Index()
        {
            List<string> wojewodztwo = (from r in db.wojewodztwa select r.wojewodztwo).
                OrderBy(r => r).ToList();
            wojewodztwo.Insert(0, "POLSKA");
            ViewBag.wojewodztwo = new SelectList(wojewodztwo, "wojewodztwo");
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(string wojewodztwo)
        {
            string query;
            if (string.Equals(wojewodztwo, "POLSKA")) {
                query = "SELECT dmy, SUM(g) g, SUM(h) h FROM WojTrendDay14View group by dmy";
            }
            else
            query = "SELECT dmy, g, h FROM WojTrendDay14View WHERE wojewodztwo=@wojewodztwo";
            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "data",
                            "zgony w wyniku covid bez chorób współistniejących",
                            "zgony w wyniku covid i chorób współistniejących"
                        });
            using (SqlConnection connection = new SqlConnection(constructor))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@wojewodztwo", wojewodztwo);
                    connection.Open();
                    using (SqlDataReader sql_data_reader = cmd.ExecuteReader())
                    {
                        while (sql_data_reader.Read())
                        {
                            chart_data.Add(new object[]
                        {
                            sql_data_reader["dmy"].ToString(),
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