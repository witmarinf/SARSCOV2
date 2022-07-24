﻿using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Linq;
using SARSCOV2.ModelsDB;

namespace SARSCOV2.Controllers
    {
        public class WojTrendMonthController : Controller
        {
            DBEntities db = new DBEntities();

            public ActionResult Index()
            {
                var wojewodztwo = (from r in db.wojewodztwa select r.wojewodztwo).OrderBy(r => r).ToList();
                ViewBag.wojewodztwo = new SelectList(wojewodztwo, "wojewodztwo");
                return View();
            }

            [HttpPost]
            public JsonResult AjaxMethod(string wojewodztwo)
            {
                string query = "SELECT c,f,g FROM WojTrendMonthView WHERE wojewodztwo=@wojewodztwo";

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
                        cmd.Parameters.AddWithValue("@wojewodztwo", wojewodztwo);
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


    