using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Services_SPA.Models;
namespace Services_SPA.App_Start
{
    public class Select
    {
        private MySqlConnection conn;
        public Select()
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

        public List<SelectModel> getWell(int province_id, int amphur_code)
        {
            
            MySqlConnection con = WebApiConfig.conn();

            MySqlCommand cm     = con.CreateCommand();

            cm.CommandText      = "select * from weightfactor where PROVINCE_ID =" + province_id +" and AMPHUR_CODE =" + amphur_code +" and TYPE = 1 ;";

            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            var resultWell = new List<SelectModel>();
            MySqlDataReader mySQLReader = cm.ExecuteReader();

            while (mySQLReader.Read())
            {
                SelectModel sl  = new SelectModel();
                sl.id           = mySQLReader.GetInt32(0);
                sl.province_id  = mySQLReader.GetInt32(1);
                sl.amphur_code  = mySQLReader.GetInt32(2);
                sl.type         = mySQLReader.GetInt32(3);
                sl.factor_name  = mySQLReader.GetString(4);
                sl.weight       = mySQLReader.GetFloat(5);
                resultWell.Add(sl);
            }
            return resultWell;
        }
        public List<SelectModel> getRoad(int province_id, int amphur_code)
        {

            MySqlConnection con = WebApiConfig.conn();

            MySqlCommand cm = con.CreateCommand();

            cm.CommandText = "select * from weightfactor where PROVINCE_ID =" + province_id + " and AMPHUR_CODE =" + amphur_code + " and TYPE = 2 ;";

            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            var resultRoad = new List<SelectModel>();
            MySqlDataReader mySQLReader = cm.ExecuteReader();

            while (mySQLReader.Read())
            {
                SelectModel sl = new SelectModel();
                sl.id = mySQLReader.GetInt32(0);
                sl.province_id = mySQLReader.GetInt32(1);
                sl.amphur_code = mySQLReader.GetInt32(2);
                sl.type = mySQLReader.GetInt32(3);
                sl.factor_name = mySQLReader.GetString(4);
                sl.weight = mySQLReader.GetFloat(5);
                resultRoad.Add(sl);
            }
            return resultRoad;
        }
        public List<SelectModel> getShape(int province_id, int amphur_code)
        {

            MySqlConnection con = WebApiConfig.conn();

            MySqlCommand cm = con.CreateCommand();

            cm.CommandText = "select * from weightfactor where PROVINCE_ID =" + province_id + " and AMPHUR_CODE =" + amphur_code + " and TYPE = 3 ORDER BY FACTOR_NAME;";

            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            var resultShape = new List<SelectModel>();
            MySqlDataReader mySQLReader = cm.ExecuteReader();

            while (mySQLReader.Read())
            {
                SelectModel sl = new SelectModel();
                sl.id = mySQLReader.GetInt32(0);
                sl.province_id = mySQLReader.GetInt32(1);
                sl.amphur_code = mySQLReader.GetInt32(2);
                sl.type = mySQLReader.GetInt32(3);
                sl.factor_name = mySQLReader.GetString(4);
                sl.weight = mySQLReader.GetFloat(5);
                resultShape.Add(sl);
            }
            return resultShape;
        }
        public List<SelectModel> getWidth(int province_id, int amphur_code)
        {

            MySqlConnection con = WebApiConfig.conn();

            MySqlCommand cm = con.CreateCommand();

            cm.CommandText = "select * from weightfactor where PROVINCE_ID =" + province_id + " and AMPHUR_CODE =" + amphur_code + " and TYPE = 4 ;";

            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            var resultWidth = new List<SelectModel>();
            MySqlDataReader mySQLReader = cm.ExecuteReader();

            while (mySQLReader.Read())
            {
                SelectModel sl = new SelectModel();
                sl.id = mySQLReader.GetInt32(0);
                sl.province_id = mySQLReader.GetInt32(1);
                sl.amphur_code = mySQLReader.GetInt32(2);
                sl.type = mySQLReader.GetInt32(3);
                sl.factor_name = mySQLReader.GetString(4);
                sl.weight = mySQLReader.GetFloat(5);
                resultWidth.Add(sl);
            }
            return resultWidth;
        }
        public List<SelectModel> getSize(int province_id, int amphur_code)
        {

            MySqlConnection con = WebApiConfig.conn();

            MySqlCommand cm = con.CreateCommand();

            cm.CommandText = "select * from weightfactor where PROVINCE_ID =" + province_id + " and AMPHUR_CODE =" + amphur_code + " and TYPE = 5 ;";

            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            var resultSize = new List<SelectModel>();
            MySqlDataReader mySQLReader = cm.ExecuteReader();

            while (mySQLReader.Read())
            {
                SelectModel sl = new SelectModel();
                sl.id = mySQLReader.GetInt32(0);
                sl.province_id = mySQLReader.GetInt32(1);
                sl.amphur_code = mySQLReader.GetInt32(2);
                sl.type = mySQLReader.GetInt32(3);
                sl.factor_name = mySQLReader.GetString(4);
                sl.weight = mySQLReader.GetFloat(5);
                resultSize.Add(sl);
            }
            return resultSize;
        }

    }
}
