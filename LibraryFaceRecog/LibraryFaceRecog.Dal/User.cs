using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryFaceRecog.Core;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibraryFaceRecog.Dal
{
    public class User
    {
        private static string ConnectionString()
        {
            return PublicVariables.ConnectionString;
        }

        public static string GetUsersErrorMessage;
        public static bool GetUsersSuccessful;
        public static DataTable GetUsers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_get_all_users", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_username", PublicVariables.UserName));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    GetUsersSuccessful = true;
                    return dt;
                }
            }
            catch (Exception ex)
            {
                GetUsersSuccessful = false;
                GetUsersErrorMessage = ex.Message + "\nFunction : Get Users";
                return null;
            }
        }
    }
}
