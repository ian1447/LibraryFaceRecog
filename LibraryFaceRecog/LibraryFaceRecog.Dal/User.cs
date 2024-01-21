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

        public static string AddUserErrorMessage;
        public static bool AddUserSuccessful;
        public static void AddUser(string _username, string _password, string _privilege)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_users_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_username", _username));
                    cmd.Parameters.Add(new MySqlParameter("_password", _password));
                    cmd.Parameters.Add(new MySqlParameter("_privilege", _privilege));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    AddUserSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                AddUserSuccessful = false;
                AddUserErrorMessage = ex.Message + "\nFunction : Adding User";
            }
        }

        public static string EdituserErrorMessage;
        public static bool EdituserSuccessful;
        public static void Edituser(string _username, string _password, string _privilege, string _id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_users_edit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_username", _username));
                    cmd.Parameters.Add(new MySqlParameter("_password", _password));
                    cmd.Parameters.Add(new MySqlParameter("_privilege", _privilege));
                    cmd.Parameters.Add(new MySqlParameter("_id", _id));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    EdituserSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                EdituserSuccessful = false;
                EdituserErrorMessage = ex.Message + "\nFunction : Editing User";
            }
        }

        public static string UpdateIsactiveUserErrorMessage;
        public static bool UpdateUserStatusSuccessful;
        public static void UpdateUserStatus(string _id, int _mode)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_user_update_active_status", con);
                    cmd.Parameters.Add(new MySqlParameter("_id", _id));
                    cmd.Parameters.Add(new MySqlParameter("_mode", _mode));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    UpdateUserStatusSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                UpdateUserStatusSuccessful = false;
                UpdateIsactiveUserErrorMessage = ex.Message + "\nFunction : Update user status";
            }
        }
    }
}
