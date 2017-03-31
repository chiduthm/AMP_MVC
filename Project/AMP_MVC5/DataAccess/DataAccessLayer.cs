using AMP_MVC5.Models;
using AMPMVC5;
using AMPMVC5.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AMP_MVC5.DataAccess
{
    public class DataAccessLayer
    {

        public string InsertData(Customer objcust)
        {

            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", 0);
                cmd.Parameters.AddWithValue("@Name", objcust.Name);
                cmd.Parameters.AddWithValue("@Address", objcust.Address);
                cmd.Parameters.AddWithValue("@Mobileno", objcust.Mobileno);
                cmd.Parameters.AddWithValue("@Birthdate", objcust.Birthdate);
                cmd.Parameters.AddWithValue("@EmailID", objcust.EmailID);
                cmd.Parameters.AddWithValue("@Query", 1);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }


        public string UpdateData(Customer objcust)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", objcust.CustomerID);
                cmd.Parameters.AddWithValue("@Name", objcust.Name);
                cmd.Parameters.AddWithValue("@Address", objcust.Address);
                cmd.Parameters.AddWithValue("@Mobileno", objcust.Mobileno);
                cmd.Parameters.AddWithValue("@Birthdate", objcust.Birthdate);
                cmd.Parameters.AddWithValue("@EmailID", objcust.EmailID);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }


        public string DeleteData(Customer objcust)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", objcust.CustomerID);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@Mobileno", null);
                cmd.Parameters.AddWithValue("@Birthdate", null);
                cmd.Parameters.AddWithValue("@EmailID", null);
                cmd.Parameters.AddWithValue("@Query", 3);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }


        public List<Customer> Selectalldata()
        {
            SqlConnection con = null;

            DataSet ds = null;
            List<Customer> custlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", null);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@Mobileno", null);
                cmd.Parameters.AddWithValue("@Birthdate", null);
                cmd.Parameters.AddWithValue("@EmailID", null);
                cmd.Parameters.AddWithValue("@Query", 4);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Customer>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Customer cobj = new Customer();
                    cobj.CustomerID = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerID"].ToString());
                    cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    cobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                    cobj.Mobileno = ds.Tables[0].Rows[i]["Mobileno"].ToString();
                    cobj.EmailID = ds.Tables[0].Rows[i]["EmailID"].ToString();
                    cobj.Birthdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthdate"].ToString());

                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }


        public List<Location> SelectallLocationdata()
        {
            SqlConnection con = null;

            DataSet ds = null;
            List<Location> custlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("spGetLoctionToDisplay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Location>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Location lobj = new Location();
                    lobj.LocationID = Convert.ToInt32(ds.Tables[0].Rows[i]["LocationID"].ToString());
                    lobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    lobj.Latitude = ds.Tables[0].Rows[i]["Latitude"].ToString();
                    lobj.Longitude = ds.Tables[0].Rows[i]["Longitude"].ToString();
                    lobj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    custlist.Add(lobj);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

        public Customer SelectDatabyID(string CustomerID)
        {
            SqlConnection con = null;
            DataSet ds = null;
            Customer cobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@Mobileno", null);
                cmd.Parameters.AddWithValue("@Birthdate", null);
                cmd.Parameters.AddWithValue("@EmailID", null);
                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new Customer();
                    cobj.CustomerID = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerID"].ToString());
                    cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    cobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                    cobj.Mobileno = ds.Tables[0].Rows[i]["Mobileno"].ToString();
                    cobj.EmailID = ds.Tables[0].Rows[i]["EmailID"].ToString();
                    cobj.Birthdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthdate"].ToString());
                }
                return cobj;
            }
            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }
        }


        public string InsertLocData(Location objloc)
        {

            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("sp_IUD_Location", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationID", 0);
                cmd.Parameters.AddWithValue("@Name", objloc.Name);
                cmd.Parameters.AddWithValue("@Latitude", objloc.Latitude);
                cmd.Parameters.AddWithValue("@Longitude", objloc.Longitude);
                cmd.Parameters.AddWithValue("@Description", objloc.Description);
                cmd.Parameters.AddWithValue("@Query", 1);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch(Exception ex)
            {
                string t = ex.Message;
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }


        public Location SelectLocationDatabyID(string LocationID)
        {
            SqlConnection con = null;
            DataSet ds = null;
            Location lobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("sp_IUD_Location", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Latitude", null);
                cmd.Parameters.AddWithValue("@Longitude", null);
                cmd.Parameters.AddWithValue("@Description", null);
                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lobj = new Location();
                    lobj.LocationID = Convert.ToInt32(ds.Tables[0].Rows[i]["LocationID"].ToString());
                    lobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    lobj.Latitude = ds.Tables[0].Rows[i]["Latitude"].ToString();
                    lobj.Longitude = ds.Tables[0].Rows[i]["Longitude"].ToString();
                    lobj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    
                }
                return lobj;
            }
            catch(Exception ex)
            {
                string x = ex.Message;
                return lobj;
            }
            finally
            {
                con.Close();
            }
        }

        public string UpdateLocationData(Location objloc)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("sp_IUD_Location", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationID", objloc.LocationID);
                cmd.Parameters.AddWithValue("@Name", objloc.Name);
                cmd.Parameters.AddWithValue("@Latitude", objloc.Latitude);
                cmd.Parameters.AddWithValue("@Longitude", objloc.Longitude);
                cmd.Parameters.AddWithValue("@Description", objloc.Description);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public List<AppointmentDiary> SelectallAvailabilitydata(string userId)

        {
            SqlConnection con = null;

            DataSet ds = null;
            List<AppointmentDiary> aptlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("sp_IUD_Availability", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Query", 4);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                aptlist = new List<AppointmentDiary>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string StringDate = string.Format("{0:yyyy-MM-dd}", ds.Tables[0].Rows[i]["DateTimeScheduled"]);
                    AppointmentDiary aobj = new AppointmentDiary();
                    aobj.id = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    aobj.someKey = Convert.ToInt16(ds.Tables[0].Rows[i]["SomeImportantKey"]);
                    aobj.allDay = Convert.ToInt16(ds.Tables[0].Rows[i]["StatusENUM"]);
                    aobj.title =Convert.ToString(ds.Tables[0].Rows[i]["Title"]);
                    aobj.start = StringDate + "T00:00:00"; 
                    aobj.end = StringDate + "T23:59:59";
                    aptlist.Add(aobj);
                }
                return aptlist;
            }
            catch
            {
                return aptlist;
            }
            finally
            {
                con.Close();
            }
        }





    }
}