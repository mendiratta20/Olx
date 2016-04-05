using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using OlxAd.Models;



namespace OlxAd.DataAccessLayer
{
    public class DBData
    {


        public bool Validate(Users user)
        {


            string connectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            List<Users> users = new List<Users>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_ValidateUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    return true;

                }
                else
                    return false;


            }



        }

        public bool InsertData(Registration Reg)
        {
            SqlConnection con = null;
            bool retval;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

                con.Open();
                SqlCommand cmd1 = new SqlCommand("Sp_checkname", con);
                cmd1.Parameters.AddWithValue("@Name", Reg.Username);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd1.ExecuteReader();
                if (!dr.HasRows)
                {

                    retval = true;
                    SqlCommand cmd = new SqlCommand("Sp_RegisterUsers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", Reg.Username);
                    cmd.Parameters.AddWithValue("@Password", Reg.Password);
                    //con.Open();
                    cmd.ExecuteScalar();
                }
                else
                {
                    retval = false;
                }


                return retval;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertdataforADS(InsertAds Insert,int UserNo)
        {
            SqlConnection con = null;

        
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("Sp_InsertAds", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserNo", UserNo);
                cmd.Parameters.AddWithValue("@ItemType", Insert.ItemType);
                cmd.Parameters.AddWithValue("@Image", Insert.Image);
                cmd.Parameters.AddWithValue("@Phone", Insert.Phone);
                cmd.Parameters.AddWithValue("@Address", Insert.Address);


                //con.Open();
                cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }





        }



       public List<InsertAds> selectingAds(Select selectAds,int UserNo)
        {
            SqlConnection con = null;
            List<InsertAds> selectlist = new List<InsertAds>();




            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                con.Open();

                SqlCommand cmd = new SqlCommand("Sp_SelectAds", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemType", selectAds.Category);
                cmd.Parameters.AddWithValue("@UserNo", UserNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    InsertAds insert = new InsertAds();
                    insert.Id = dr.GetInt32(0);
                    insert.Image = dr.GetString(3);
                    insert.Phone = dr.GetString(4);
                    insert.Address = dr.GetString(5);
                    selectlist.Add(insert);


                }
                dr.Close();


               // cmd.ExecuteScalar();

                return selectlist;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }





        }
        
        

        

        public List<InsertAds> ViewAds( string category)
        {
            SqlConnection con = null;
            List<InsertAds> AdsList = new List<InsertAds>();


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                SqlCommand cmd = new SqlCommand("Sp_ViewAds", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@itemtype", category);


                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    InsertAds Ad = new InsertAds();

                    //mob_Ad.UserNo = rdr.GetInt32(1);
                    // mob_Ad.ItemType = rdr.GetString(2);
                    Ad.Image = rdr.GetString(3);
                    Ad.Phone = rdr.GetString(4);
                    Ad.Address = rdr.GetString(5);
                    AdsList.Add(Ad);
                }
                return AdsList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        public int FetchUserNo(string username)
        {
            SqlConnection con = null;

            int emp_id = -1;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                con.Open();
                //  Registration reg = new Registration();
                SqlCommand cmd1 = new SqlCommand("Sp_FetchUserNo", con);

                //reg.Username = "Nikita";
                cmd1.Parameters.AddWithValue("@Name", username);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        emp_id = Convert.ToInt32(dr[0]);


                    }
                }
                else
                {

                    emp_id = -1;
                }
            }
            catch
            {

            }
            return emp_id;
        }



        public List<InsertAds> MyAds(int UserNo)
        {
            SqlConnection con = null;
            List<InsertAds> selectlist = new List<InsertAds>();




            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                con.Open();

                SqlCommand cmd = new SqlCommand("Sp_MyAds", con);
                cmd.CommandType = CommandType.StoredProcedure;
           
                cmd.Parameters.AddWithValue("@UserNo", UserNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    InsertAds insert = new InsertAds();
                    insert.Id = dr.GetInt32(0);
                    insert.Image = dr.GetString(3);
                    insert.Phone = dr.GetString(4);
                    insert.Address = dr.GetString(5);
                    selectlist.Add(insert);


                }
                dr.Close();


                // cmd.ExecuteScalar();

                return selectlist;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }





        }


        public bool DeleteDataforADS(int id)
        {
            SqlConnection con = null;
            bool result = false;

           



            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                con.Open();

                SqlCommand cmd1 = new SqlCommand("Sp_deleteADs", con);
     


                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Id", id);
                cmd1.ExecuteScalar();
                result=true;


                
                }



            
            catch (Exception ex)
            {
                throw ex;
                
            }
            finally
            {
                con.Close();
            }
            return result;
            //return retval;






        }
 
    
    }




}