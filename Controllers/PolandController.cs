using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace GooglePie.Controllers
{
    public class PolandController : Controller
    {
        // GET: MapaPolski
        public ActionResult Indexc()
        {
            //ViewBag.gender = gender;
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodc()
        {
            string query = "select a, b, c from PolandMapView";


            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "kod",
                            "województwo",
                            "liczba osób objętych kwarantanną",

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
                            sql_data_reader["a"].ToString(),
                            sql_data_reader["b"].ToString(),
                            sql_data_reader["c"]


                        });
                        }
                    }

                    connection.Close();
                }
            }
            return Json(chart_data);
        }


        public ActionResult Indexd()
        {
           
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodd()
        {
            string query = "select a, b, d from PolandMapView";


            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "kod",
                            "województwo",
                            "liczba ozdrowieńców",

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
                            sql_data_reader["a"].ToString(),
                            sql_data_reader["b"].ToString(),
                            sql_data_reader["d"]


                        });
                        }
                    }

                    connection.Close();
                }
            }
            return Json(chart_data);
        }







        public ActionResult Indexe()
        {

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethode()
        {
            string query = "select a, b, e from PolandMapView";


            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "kod",
                            "województwo",
                            "liczba osób, których poprzedniej doby wynik był pozytwny",

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
                            sql_data_reader["a"].ToString(),
                            sql_data_reader["b"].ToString(),
                            sql_data_reader["e"]


                        });
                        }
                    }

                    connection.Close();
                }
            }
            return Json(chart_data);
        }

 
        //liczba osób z wynikiem negatywnym 
        public ActionResult Indexf()
        {

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodf()
        {
            string query = "select a, b, f from PolandMapView";


            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "kod",
                            "województwo",
                            "liczba osób, których wynik w ciągu ostatniej doby był negatywny",

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
                            sql_data_reader["a"].ToString(),
                            sql_data_reader["b"].ToString(),
                            sql_data_reader["f"]


                        });
                        }
                    }

                    connection.Close();
                }
            }
            return Json(chart_data);
        }




        //liczba osób z wynikiem pozytywnym 
        public ActionResult Indexg()
        {

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodg()
        {
            string query = "select a, b, g from PolandMapView";


            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "kod",
                            "województwo",
                            "liczba osób, których wynik w ciągu ostatniej doby był pozytwny",
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
                            sql_data_reader["a"].ToString(),
                            sql_data_reader["b"].ToString(),
                            sql_data_reader["g"]


                        });
                        }
                    }

                    connection.Close();
                }
            }
            return Json(chart_data);
        }



        //liczba wykonanych testów
        public ActionResult Indexh()
        {

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodh()
        {
            string query = "select a, b, h from PolandMapView";


            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "kod",
                            "województwo",
                            "liczba wykonanych testów w ciągu ostatniej doby",
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
                            sql_data_reader["a"].ToString(),
                            sql_data_reader["b"].ToString(),
                            sql_data_reader["h"]


                        });
                        }
                    }

                    connection.Close();
                }
            }
            return Json(chart_data);
        }


        //liczba testów zleconych przez podstawową opiekę zdrowotną

        public ActionResult Indexi()
        {

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodi()
        {
            string query = "select a, b, i from PolandMapView";


            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "kod",
                            "województwo",
                            "liczba wykonanych testów w ciągu ostatniej doby",
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
                            sql_data_reader["a"].ToString(),
                            sql_data_reader["b"].ToString(),
                            sql_data_reader["i"]


                        });
                        }
                    }

                    connection.Close();
                }
            }
            return Json(chart_data);
        }



        public ActionResult Indexj()
        {

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodj()
        {
            string query = "select a, b, j from PolandMapView";


            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "kod",
                            "województwo",
                            "liczba zgonów",
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
                            sql_data_reader["a"].ToString(),
                            sql_data_reader["b"].ToString(),
                            sql_data_reader["j"]


                        });
                        }
                    }

                    connection.Close();
                }
            }
            return Json(chart_data);
        }



        //zgony_w_wyniku_covid_bez_chorob_wspolistniejacych
        public ActionResult Indexk()
        {

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodk()
        {
            string query = "select a, b, k from PolandMapView";


            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "kod",
                            "województwo",
                            "liczba zgonów w wyniku covid bez chorób współistniejących",
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
                            sql_data_reader["a"].ToString(),
                            sql_data_reader["b"].ToString(),
                            sql_data_reader["k"]


                        });
                        }
                    }

                    connection.Close();
                }
            }
            return Json(chart_data);
        }


        //zgony_w_wyniku_covid_bez_chorob_wspolistniejacych
        public ActionResult Indexl()
        {

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodl()
        {
            string query = "select a, b, l from PolandMapView";


            string constructor = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chart_data = new List<object>();
            chart_data.Add(new object[]
                        {   "kod",
                            "województwo",
                            "liczba zgonów w wyniku covid i chorób współistniejących",
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
                            sql_data_reader["a"].ToString(),
                            sql_data_reader["b"].ToString(),
                            sql_data_reader["l"]


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