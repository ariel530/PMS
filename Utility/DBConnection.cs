using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace PMS.Utility
{
    public static class DBConnection
    {
        public static string userName;
        public static SqlConnection GetConnection()
        {
            string conString = ConfigurationManager.ConnectionStrings["PMS"].ConnectionString;
         //   string conString = System.Configuration.ConfigurationManager.ConnectionStrings["PMS"].ConnectionString;
         //   string conString = "Data Source=DESKTOP-DCAMECO;Initial Catalog=PMS;Integrated Security=True;";
            SqlConnection con = new SqlConnection(conString);
            return con;
        }
    }
}