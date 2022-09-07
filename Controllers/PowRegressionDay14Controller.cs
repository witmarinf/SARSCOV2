using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Linq;
using SARSCOV2.ModelsDB;

namespace SARSCOV2.Controllers
{
    public class PowRegressionDay14Controller : Controller
    {
        readonly DBEntities db = new DBEntities();
        // GET: PowRegressionDay14
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
            string query = "SELECT g, h FROM PowTrendDay14View WHERE powiat_miasto=@powiat_miasto";
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
                    cmd.Parameters.AddWithValue("@powiat_miasto", powiat_miasto);
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

        //[Authorize(Roles = "admin, manager, student")]
        [HttpPost]
        public JsonResult AjaxMethod1(string powiat_miasto)
        {
            string query = "SELECT g, h FROM PowTrendDay14WithoutWeekendsView WHERE powiat_miasto=@powiat_miasto";
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
                    cmd.Parameters.AddWithValue("@powiat_miasto", powiat_miasto);

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