using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Linq;
using SARSCOV2.ModelsDB;


namespace GooglePie.Controllers
{
    public class PolandController : Controller
    {
        readonly DBEntities db = new DBEntities();

        //Osoby objęte kwarantanną
        public ActionResult Indexc()
        {

            var termin = (from r in db.woj_target
                          select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> stan_rekordu_na = new List<string>();

            foreach (var da in termin)
            {
                stan_rekordu_na.Add(da.Value.ToString("d"));
            }

            ViewBag.stan_rekordu_na = new SelectList(stan_rekordu_na, "stan_rekordu_na");

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodc(string stan_rekordu_na)
        {
            string query = "SELECT a, b, c FROM PolandMapView WHERE stan_rekordu_na=@stan_rekordu_na";
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
                    cmd.Parameters.AddWithValue("@stan_rekordu_na", stan_rekordu_na);
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

        
         
        

        //liczba ozdrowieńców

        public ActionResult Indexd()
        {

            var termin = (from r in db.woj_target
                          select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> stan_rekordu_na = new List<string>();

            foreach (var da in termin)
            {
                stan_rekordu_na.Add(da.Value.ToString("d"));
            }

            ViewBag.stan_rekordu_na = new SelectList(stan_rekordu_na, "stan_rekordu_na");

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodd(string stan_rekordu_na)
        {
            string query = "SELECT a, b, d FROM PolandMapView  WHERE stan_rekordu_na=@stan_rekordu_na";


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
                    cmd.Parameters.AddWithValue("@stan_rekordu_na", stan_rekordu_na);
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








        //liczba osób, których poprzedniej doby wynik był pozytwny

        public ActionResult Indexe()
        {

            var termin = (from r in db.woj_target
                          select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> stan_rekordu_na = new List<string>();

            foreach (var da in termin)
            {
                stan_rekordu_na.Add(da.Value.ToString("d"));
            }

            ViewBag.stan_rekordu_na = new SelectList(stan_rekordu_na, "stan_rekordu_na");

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethode(string stan_rekordu_na)
        {
            string query = "SELECT a, b, e FROM PolandMapView  WHERE stan_rekordu_na=@stan_rekordu_na";


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
                    cmd.Parameters.AddWithValue("@stan_rekordu_na", stan_rekordu_na);
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

            var termin = (from r in db.woj_target
                          select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> stan_rekordu_na = new List<string>();

            foreach (var da in termin)
            {
                stan_rekordu_na.Add(da.Value.ToString("d"));
            }

            ViewBag.stan_rekordu_na = new SelectList(stan_rekordu_na, "stan_rekordu_na");

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodf(string stan_rekordu_na)
        {
            string query = "SELECT a, b, f FROM PolandMapView WHERE stan_rekordu_na=@stan_rekordu_na";


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
                    cmd.Parameters.AddWithValue("@stan_rekordu_na", stan_rekordu_na);
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








        //liczba osób, których wynik w ciągu ostatniej doby był pozytwny 
        public ActionResult Indexg()
        {

            var termin = (from r in db.woj_target
                          select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> stan_rekordu_na = new List<string>();

            foreach (var da in termin)
            {
                stan_rekordu_na.Add(da.Value.ToString("d"));
            }

            ViewBag.stan_rekordu_na = new SelectList(stan_rekordu_na, "stan_rekordu_na");

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodg(string stan_rekordu_na)
        {
            string query = "SELECT a, b, g FROM PolandMapView  WHERE stan_rekordu_na=@stan_rekordu_na";


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
                    cmd.Parameters.AddWithValue("@stan_rekordu_na", stan_rekordu_na);
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




        //liczba wykonanych testów w ciągu ostatniej doby
        public ActionResult Indexh()
        {

            var termin = (from r in db.woj_target
                          select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> stan_rekordu_na = new List<string>();

            foreach (var da in termin)
            {
                stan_rekordu_na.Add(da.Value.ToString("d"));
            }

            ViewBag.stan_rekordu_na = new SelectList(stan_rekordu_na, "stan_rekordu_na");

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodh(string stan_rekordu_na)
        {
            string query = "SELECT a, b, h FROM PolandMapView  WHERE stan_rekordu_na=@stan_rekordu_na";


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
                    cmd.Parameters.AddWithValue("@stan_rekordu_na", stan_rekordu_na);
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

            var termin = (from r in db.woj_target
                          select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> stan_rekordu_na = new List<string>();

            foreach (var da in termin)
            {
                stan_rekordu_na.Add(da.Value.ToString("d"));
            }

            ViewBag.stan_rekordu_na = new SelectList(stan_rekordu_na, "stan_rekordu_na");

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodi(string stan_rekordu_na)
        {
            string query = "SELECT a, b, i FROM PolandMapView  WHERE stan_rekordu_na=@stan_rekordu_na";


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
                    cmd.Parameters.AddWithValue("@stan_rekordu_na", stan_rekordu_na);
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









        //liczba zgonów

        public ActionResult Indexj()
        {
            var termin = (from r in db.woj_target
                          select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> stan_rekordu_na = new List<string>();

            foreach (var da in termin)
            {
                stan_rekordu_na.Add(da.Value.ToString("d"));
            }

            ViewBag.stan_rekordu_na = new SelectList(stan_rekordu_na, "stan_rekordu_na");

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodj(string stan_rekordu_na)
        {
            string query = "SELECT a, b, j FROM PolandMapView  WHERE stan_rekordu_na=@stan_rekordu_na";

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
                    cmd.Parameters.AddWithValue("@stan_rekordu_na", stan_rekordu_na);
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

            var termin = (from r in db.woj_target
                          select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> stan_rekordu_na = new List<string>();

            foreach (var da in termin)
            {
                stan_rekordu_na.Add(da.Value.ToString("d"));
            }

            ViewBag.stan_rekordu_na = new SelectList(stan_rekordu_na, "stan_rekordu_na");


            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodk(string stan_rekordu_na)
        {
            string query = "SELECT a, b, k FROM PolandMapView WHERE stan_rekordu_na=@stan_rekordu_na";


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
                    cmd.Parameters.AddWithValue("@stan_rekordu_na", stan_rekordu_na);
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
            var termin = (from r in db.woj_target
                          select r.stan_rekordu_na).Distinct().OrderByDescending(r => r).ToList();
            List<string> stan_rekordu_na = new List<string>();

            foreach (var da in termin)
            {
                stan_rekordu_na.Add(da.Value.ToString("d"));
            }

            ViewBag.stan_rekordu_na = new SelectList(stan_rekordu_na, "stan_rekordu_na");

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethodl(string stan_rekordu_na)
        {
            string query = "SELECT a, b, l FROM PolandMapView WHERE stan_rekordu_na=@stan_rekordu_na";


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
                    cmd.Parameters.AddWithValue("@stan_rekordu_na", stan_rekordu_na);
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