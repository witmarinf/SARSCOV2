using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SARSCOV2.ModelsDB;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SARSCOV2.Controllers
{
    public class StatController : Controller
    {
        // GET: Stat
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod1()
        {
            string query = "SELECT wojewodztwo, Sum(liczba_testow_z_wynikiem_pozytywnym) poz, " +
                "Sum(liczba_ozdrowiencow) ozd " +
                ",Sum(zgony) zgony from woj_target" +
                " where stan_rekordu_na = " +
                "(select  max(stan_rekordu_na) from woj_target) group by " +
                "wojewodztwo order by Sum(liczba_testow_z_wynikiem_pozytywnym) DESC";

            string constr = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
                        {
                            "wojewodztwo",
                            "liczba testow z wynikiem pozytywnym",
                            "liczba_ozdrowiencow",
                            "zgony",
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
                            sdr["wojewodztwo"],
                            sdr["poz"],
                            sdr["ozd"],
                            sdr["zgony"]
                        });
                        }
                    }
                    con.Close();
                }
            }
            return Json(chartData);
        }

        public JsonResult AjaxMethod1a()
        {
            string query = "SELECT wojewodztwo, Sum(liczba_testow_z_wynikiem_pozytywnym) poz from woj_target where stan_rekordu_na = " +
                "(select  max(stan_rekordu_na) from woj_target) group by " +
                "wojewodztwo order by Sum(liczba_testow_z_wynikiem_pozytywnym) DESC";

            string constr = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
                        {
                            "wojewodztwo",
                            "liczba testow z wynikiem pozytywnym",
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
                            sdr["wojewodztwo"],
                            sdr["poz"]
                        });
                        }
                    }

                    con.Close();
                }
            }
            return Json(chartData);
        }

    
        public JsonResult AjaxMethod1b()
        {
            string query = "SELECT wojewodztwo, Sum(liczba_ozdrowiencow) lo from woj_target where stan_rekordu_na = " +
                "(select  max(stan_rekordu_na) from woj_target) group by " +
                "wojewodztwo order by Sum(liczba_ozdrowiencow) DESC";

            string constr = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
                        {
                            "wojewodztwo",
                            "liczba ozdrowieńców",
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
                            sdr["wojewodztwo"],
                            sdr["lo"]
                        });
                        }
                    }

                    con.Close();
                }
            }
            return Json(chartData);
        }
 

        public JsonResult AjaxMethod1c()
        {
            string query = "SELECT wojewodztwo, Sum(zgony) poz from woj_target " +
                "where stan_rekordu_na = (select  max(stan_rekordu_na) " +
                "from woj_target) group by wojewodztwo order by " +
                "Sum(zgony) DESC";


            string constr = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
                        {
                            "wojewodztwo",
                            "liczba testow z wynikiem pozytywnym",
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
                            sdr["wojewodztwo"],
                            sdr["poz"]
                        });
                        }
                    }

                    con.Close();
                }
            }
            return Json(chartData);
        }

        [HttpPost]
        public JsonResult AjaxMethod2()
        {
            string query = "SELECT powiat_miasto, Sum(liczba_testow_z_wynikiem_pozytywnym) poz, Sum(liczba_ozdrowiencow) ozd " +
                ",Sum(zgony) zgony from pow_target where stan_rekordu_na = " +
                "(select  max(stan_rekordu_na) from pow_target) group by " +
                "powiat_miasto order by Sum(liczba_testow_z_wynikiem_pozytywnym) DESC";


            string constr = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
                        {
                            "miasto",
                            "liczba testow z wynikiem pozytywnym",
                            "liczba_ozdrowiencow",
                            "zgony",
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
                            sdr["powiat_miasto"],
                            sdr["poz"],
                            sdr["ozd"],
                            sdr["zgony"]
                        });
                        }
                    }

                    con.Close();
                }
            }
            return Json(chartData);
        }


        public JsonResult AjaxMethod2a()
        {
            string query = "SELECT powiat_miasto, Sum(liczba_testow_z_wynikiem_pozytywnym) poz " +
                "from pow_target where stan_rekordu_na = " +
                "(select  max(stan_rekordu_na) from pow_target) group by " +
                "powiat_miasto order by Sum(liczba_testow_z_wynikiem_pozytywnym) DESC";

            string constr = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
                        {
                            "miasto",
                            "liczba testow z wynikiem pozytywnym",
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
                            sdr["powiat_miasto"],
                            sdr["poz"]
                        });
                        }
                    }

                    con.Close();
                }
            }
            return Json(chartData);
        }

        public JsonResult AjaxMethod2b()
        {
            string query = "SELECT powiat_miasto, Sum(liczba_ozdrowiencow) lo " +
                "from pow_target where stan_rekordu_na = " +
                "(select  max(stan_rekordu_na) from pow_target) group by " +
                "powiat_miasto order by Sum(liczba_ozdrowiencow) DESC";


            string constr = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
                        {
                            "miasto",
                            "liczba ozdrowieńców",
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
                            sdr["powiat_miasto"],
                            sdr["lo"]
                        });
                        }
                    }

                    con.Close();
                }
            }
            return Json(chartData);
        }

       
        public JsonResult AjaxMethod2c()
        {
            string query = "SELECT powiat_miasto, " +
                "Sum(zgony) zgony from pow_target where stan_rekordu_na = " +
                "(select  max(stan_rekordu_na) from pow_target) group by " +
                "powiat_miasto order by Sum(zgony) DESC";

            string constr = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
                        {
                            "miasto",
                            "liczba zgonów",
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
                            sdr["powiat_miasto"],
                            sdr["zgony"]
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
