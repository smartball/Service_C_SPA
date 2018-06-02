using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Services_SPA.App_Start;
using Services_SPA.Models;
namespace Services_SPA.App_Start
{
    public class Amphur
    {
        private MySqlConnection conn;

        public Amphur()
        {

            string myConnectionString = "server=35.200.218.222;uid=smartball;pwd=ball1234;database=serviceSPA";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public List<AmphurModel> getAmphur(int province_id)
        {

            MySqlConnection con = WebApiConfig.conn();

            MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

            MySqlCommand cm = con.CreateCommand();
            cm.CommandText = "SELECT * FROM amphur WHERE PROVINCE_ID =" + province_id.ToString();
            try
            {
                con.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw;
            }


            mySQLReader = cm.ExecuteReader();
            var result = new List<AmphurModel>();

            while (mySQLReader.Read())
            {
                AmphurModel p = new AmphurModel();
                p.amphur_id = mySQLReader.GetInt32(0);
                p.amphur_code = mySQLReader.GetString(1);
                p.amphur_name = mySQLReader.GetString(2);
                p.geo_id = mySQLReader.GetInt32(3);
                p.province_id = mySQLReader.GetInt32(4);
                result.Add(p);
            }
            return result;

        }
    }
}
