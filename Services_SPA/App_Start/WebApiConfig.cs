using System;
using MySql.Data.MySqlClient;
namespace Services_SPA.App_Start
{
    public class WebApiConfig
    {
        public static MySqlConnection conn()
        {
            string conn_string = "server=35.200.218.222;uid=smartball;pwd=ball1234;database=serviceSPA";
            MySqlConnection con = new MySqlConnection(conn_string);
            return con;
        }

        public WebApiConfig()
        {
        }
    }
}
