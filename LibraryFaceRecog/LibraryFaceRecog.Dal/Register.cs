using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryFaceRecog.Core;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibraryFaceRecog.Dal
{
    public class Register
    {
        private static string ConnectionString()
        {
            return PublicVariables.ConnectionString;
        }

        public static string GetRegisteredBorrowersErrorMessage;
        public static bool GetRegisteredBorrowersSuccessful;
        public static DataTable GetRegisteredBorrowers(string _type)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_registered_borrowers_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_type", _type));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    GetRegisteredBorrowersSuccessful = true;
                    return dt;
                }
            }
            catch (Exception ex)
            {
                GetRegisteredBorrowersSuccessful = false;
                GetRegisteredBorrowersErrorMessage = ex.Message + "\nFunction : Get Registered Borrowers";
                return null;
            }
        }

        public static string RegisteredBorrowersAddErrorMessage;
        public static bool RegisteredBorrowersAddSuccessful;
        public static void RegisteredBorrowersAdd(string _first_name, string _middle_name, string _last_name, string _sex, string _course, string _year, string _section, byte[] _image)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_registered_borrowers_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_first_name", _first_name));
                    cmd.Parameters.Add(new MySqlParameter("_middle_name", _middle_name));
                    cmd.Parameters.Add(new MySqlParameter("_last_name", _last_name));
                    cmd.Parameters.Add(new MySqlParameter("_sex", _sex));
                    cmd.Parameters.Add(new MySqlParameter("_course", _course));
                    cmd.Parameters.Add(new MySqlParameter("_year", _year));
                    cmd.Parameters.Add(new MySqlParameter("_section", _section));
                    cmd.Parameters.Add("_image", MySqlDbType.Blob);
                    cmd.Parameters["_image"].Value = _image;
                    //cmd.Parameters.Add(new MySqlParameter("_image", _image), MySqlDbType.Blob);
                    cmd.Parameters.Add(new MySqlParameter("_type", PublicVariables.AccountType));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    RegisteredBorrowersAddSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                RegisteredBorrowersAddSuccessful = false;
                RegisteredBorrowersAddErrorMessage = ex.Message + "\nFunction : Add Registered Borrowers";
            }
        }

        public static string RegisteredBorrowersEditErrorMessage;
        public static bool RegisteredBorrowersEditSuccessful;
        public static void RegisteredBorrowersEdit(string _first_name, string _middle_name, string _last_name, string _sex, string _course, string _year, string _section, byte[] _image,int _edit_id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_registered_borrowers_edit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_first_name", _first_name));
                    cmd.Parameters.Add(new MySqlParameter("_middle_name", _middle_name));
                    cmd.Parameters.Add(new MySqlParameter("_last_name", _last_name));
                    cmd.Parameters.Add(new MySqlParameter("_sex", _sex));
                    cmd.Parameters.Add(new MySqlParameter("_course", _course));
                    cmd.Parameters.Add(new MySqlParameter("_year", _year));
                    cmd.Parameters.Add(new MySqlParameter("_section", _section));
                    cmd.Parameters.Add(new MySqlParameter("_edit_id", _edit_id));
                    cmd.Parameters.Add("_image", MySqlDbType.Blob);
                    cmd.Parameters["_image"].Value = _image;
                    //cmd.Parameters.Add(new MySqlParameter("_image", _image), MySqlDbType.Blob);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    RegisteredBorrowersEditSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                RegisteredBorrowersEditSuccessful = false;
                RegisteredBorrowersEditErrorMessage = ex.Message + "\nFunction : Edit Registered Borrowers";
            }
        }
    }
}
