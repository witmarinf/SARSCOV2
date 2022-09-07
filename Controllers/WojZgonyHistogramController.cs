using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Linq;
using SARSCOV2.ModelsDB;

namespace SARSCOV2.Controllers.Controllers
{
    public class WojZgonyHistogramController : Controller
    {
        DBEntities db = new DBEntities();


        //[Authorize(Roles = "admin, manager, student")]
        public ActionResult Index()
        {
            List<string> wojewodztwo = (from r in db.woj_target select r.wojewodztwo)
                .Distinct().OrderBy(r => r).ToList();
            wojewodztwo.Insert(0, "POLSKA");
            ViewBag.wojewodztwo = new SelectList(wojewodztwo, "wojewodztwo");

            return View();
        }


        //[Authorize(Roles = "admin, manager, student")]
        [HttpPost]
        public JsonResult AjaxMethod(string wojewodztwo)
        {
            string query;
            if (string.Equals(wojewodztwo, "POLSKA"))
            {
                query = "SELECT dzien, zgony FROM WojZgonyAllView";
            }
            else
            {
                query = "SELECT dzien, zgony FROM WojZgonyAllView WHERE wojewodztwo=@wojewodztwo ";

            }

            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "dzien",
                            "zgony",
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
                            sql_data_reader["dzien"].ToString(),
                            sql_data_reader["zgony"]
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