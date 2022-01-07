using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;


namespace SARSCOV2C.Controllers
{
    public class Pie1Controller : Controller
    {
        // GET: Pie1
   
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult AjaxMethod()
        {
            string query = "SELECT top 8 wojewodztwo, SUM(zgony) zgon from";
            query += " woj_target group by wojewodztwo order by sum(zgony) DESC";
            string constr = ConfigurationManager.ConnectionStrings["C1"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
                        {
                            "wojewodztwo", "zgon"
                        });
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                        {
                            sdr["wojewodztwo"].ToString(), sdr["zgon"]
                        });
                        }
                    }
                    con.Close();
                }
            }
            return Json(chartData);
        }
    }
}