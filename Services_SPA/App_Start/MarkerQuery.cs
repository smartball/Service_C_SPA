using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Services_SPA.Models;
namespace Services_SPA.App_Start
{
    public class MarkerQuery
    {
        private MySqlConnection conn;
        public MarkerQuery()
        {
            string myConnectionString;
            myConnectionString = "server=35.200.218.222;uid=smartball;pwd=ball1234;database=serviceSPA";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

            }
            catch (MySqlException ex)
            {

            }
        }
        public List<Marker> getMarker(int deed_number, int province_id, int amphur_code){
            
            MySqlConnection con = WebApiConfig.conn();

            MySqlCommand cm = con.CreateCommand();

            cm.CommandText = "SELECT * from property where DEED_NUMBER =" + deed_number +" and PROVINCE_ID =" + province_id +" and AMPHUR_CODE ="+ amphur_code;

            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            var resultMarker = new List<Marker>();

            MySqlDataReader mySQLReader = cm.ExecuteReader();

            while(mySQLReader.Read())
            {
                Marker mark = new Marker();
               
                mark.deed_number = mySQLReader.GetInt32(0);
                mark.province_id = mySQLReader.GetInt32(1);
                mark.amphur_code = mySQLReader.GetInt32(2);
                mark.size = mySQLReader.GetInt32(3);
                mark.lat = mySQLReader.GetFloat(4);
                mark.lng = mySQLReader.GetFloat(5);
                mark.cost_appraisal = mySQLReader.GetInt32(6);
                resultMarker.Add(mark);
            }
            return resultMarker;
        }
    }
}
