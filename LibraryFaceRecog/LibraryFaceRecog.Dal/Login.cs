using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryFaceRecog.Core;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibraryFaceRecog.Dal
{
    public class Login
    {
        private static string ConnectionString()
        {
            return PublicVariables.ConnectionString;
        }

        public static string TestConnectionErrorMessage;
        public static bool ConnectionIsGood = false;
        public static bool testconnection(string conn)
        {

            try
            {
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    con.Open();
                    ConnectionIsGood = true;
                    return true;
                }
            }
            catch (Exception ex)
            {
                TestConnectionErrorMessage = ex.Message + " Function: Check Server Connection";
                ConnectionIsGood = false;
                return false;
            }
        }

        public static string LoginErrorMessage;
        public static bool LoginIsSuccessful;
        public static DataTable Userlogin(string username, string password)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_users_login", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_username", username));
                    cmd.Parameters.Add(new MySqlParameter("_password", password));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    LoginIsSuccessful = true;
                    return dt;
                }
            }
            catch (Exception ex)
            {
                LoginIsSuccessful = false;
                LoginErrorMessage = ex.Message + "\nFunction : User's Login";
                return null;
            }
        }
    }
}
