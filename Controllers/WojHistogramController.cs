using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Linq;
using SARSCOV2.ModelsDB;
using System;

namespace SARSCOV2.Controllers
{
    public class WojHistogramController : Controller
    {
        DBEntities db = new DBEntities();

        //[Authorize(Roles = "admin, manager, student")]

        public ActionResult Index()
        {
            var wojewodztwo = (from r in db.wojewodztwa select r.wojewodztwo).OrderBy(r => r).ToList();
            ViewBag.wojewodztwo = new SelectList(wojewodztwo, "wojewodztwo");
            return View();
        }

        //[Authorize(Roles = "admin, manager, student")]

        [HttpPost]
        public JsonResult AjaxMethod(DateTime start, DateTime stop, String wojewodztwo)
        {
            string query = "SELECT zgony FROM woj_target WHERE wojewodztwo =@wojewodztwo  AND " +
                "stan_rekordu_na BETWEEN " +
                "@start AND @stop";
            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {  //"stan_rekordu_na",
                            "zgony"

                        });
            using (SqlConnection connection = new SqlConnection(constructor))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", stop);
                    cmd.Parameters.AddWithValue("@wojewodztwo", wojewodztwo);
                    connection.Open();
                    using (SqlDataReader sql_data_reader = cmd.ExecuteReader())
                    {
                        while (sql_data_reader.Read())
                        {
                            chart_data.Add(new object[]
                        {
                           // sql_data_reader["stan_rekordu_na"].ToString(),

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