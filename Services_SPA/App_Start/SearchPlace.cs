using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Services_SPA.Models;
namespace Services_SPA.App_Start
{
    public class SearchPlace
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;
        public SearchPlace()
        {
            string myConnectionString;
            myConnectionString = "server=35.200.218.222;uid=smartball;pwd=ball1234;database=serviceSPA";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
        }
        public string getPlace(string lat, string lng)
        {
            MySqlConnection con = WebApiConfig.conn();

            MySqlDataReader mySQLReader = null;

            MySqlCommand cm = con.CreateCommand();
            //cm.CommandText = "select sum(WEIGHTOFFACTOR) from weightfactor where PROVINCE_ID = 1 and AMPHUR_CODE = 1011 and ID = 1 or ID = 2 or ID = 3 OR ID = 4 OR ID = 5";
            cm.CommandText = "SELECT DISTINCT sum(c1.WEIGHTOFTYPE) as sum FROM weightlocation AS c1 INNER JOIN (SELECT type, ( 6373 * acos( cos( radians(" + lat + ") ) * cos( radians( lat ) ) * cos( radians( lng ) - radians(" + lng + ") ) + sin( radians(" + lat + ") ) * sin( radians( lat ) ) ) ) AS distance FROM location WHERE PROVINCE_ID = 1 HAVING distance < 100 ) AS c2 ON c1.TYPE = c2.TYPE";
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }


            mySQLReader = cm.ExecuteReader();

            if (mySQLReader.Read())
            {
                
                var test = mySQLReader["sum"].ToString();
                return test;


            }
            else
            {
                return null;
            }


         }
        public string getWeight(int province_id, int amphur_code, int well, int road, int shape, int width, int type_size, int distance)
        {
            MySqlConnection con = WebApiConfig.conn();
            MySqlCommand weight_fac = con.CreateCommand();
            weight_fac.CommandText = "select sum(WEIGHTOFFACTOR) as sum from weightfactor where PROVINCE_ID =" + province_id +" and AMPHUR_CODE =" + amphur_code +" and ID =" + well +" or ID =" + road +" or ID =" + shape +" OR ID =" + width +" OR ID =" + type_size +" OR ID =" + distance;
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            MySqlDataReader sqlWeigt = weight_fac.ExecuteReader();
            if (sqlWeigt.Read())
            {
                var Result_Weight = sqlWeigt["sum"].ToString();
                return Result_Weight;
            }
            else
            {
                return null;
            }

        }
        public string getRoad()
        {
            MySqlConnection con = WebApiConfig.conn();
            MySqlCommand road_fac = con.CreateCommand();
            road_fac.CommandText = "SELECT weightroad.WEIGHTOFTYPE as sum FROM weightroad INNER join  road on road.TYPE = weightroad.TYPE where road.NAME = 'ลาดกระบัง' ";
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            MySqlDataReader sqlWeigt = road_fac.ExecuteReader();
            if (sqlWeigt.Read())
            {
                var Result_Weight = sqlWeigt["sum"].ToString();
                return Result_Weight;
            }
            else
            {
                return null;
            }
        }
    }
}