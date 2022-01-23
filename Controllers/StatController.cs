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
        /*
         public ActionResult Index()
          {
              return View();
          }
        */

        public ActionResult Index()
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["C2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "Select Format(min(w.stan_rekordu_na),'dd/MM/yyyy') minw,"
                             + "Format(max(w.stan_rekordu_na),'dd/MM/yyyy') maxw," 
                             + "Format(min(p.stan_rekordu_na),'dd/MM/yyyy') minp,"
                             + "Format(max(p.stan_rekordu_na),'dd/MM/yyyy') maxp from woj_target w, pow_target p";

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }
            return View(ds);
        }





        [HttpPost]
        public JsonResult AjaxMethod1()
        {    //stan_rekordu_na = (select  max(stan_rekordu_na) from woj_target)
             //stan_rekordu_na>=(select DATEADD(day,-7, max(stan_rekordu_na)) from woj_source)
            /* string query = "SELECT wojewodztwo, Sum(liczba_testow_z_wynikiem_pozytywnym) poz," +
                 "Sum(liczba_ozdrowiencow) ozd, Sum(zgony) zgony from woj_target where" +
                 "stan_rekordu_na = (select  max(stan_rekordu_na) from woj_target)" +
                 "group by wojewodztwo order by Sum(liczba_testow_z_wynikiem_pozytywnym) DESC";
            */

            string query = "SELECT wojewodztwo, Sum(liczba_testow_z_wynikiem_pozytywnym) poz, Sum(liczba_ozdrowiencow) ozd " +
                ",Sum(zgony) zgony from woj_target where " +
                "stan_rekordu_na = (select  max(stan_rekordu_na) from woj_target)" +
                "group by wojewodztwo order by Sum(liczba_testow_z_wynikiem_pozytywnym) DESC";



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
            string query = "SELECT wojewodztwo, Sum(liczba_testow_z_wynikiem_pozytywnym) poz " +
                "from woj_target where stan_rekordu_na = " +
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
