using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryFaceRecog.Core;
using LibraryFaceRecog.Dal;
using System.Data;
using MySql.Data.MySqlClient;

namespace LibraryFaceRecog.Dal
{
    public class Entrance
    {
        private static string ConnectionString()
        {
            return PublicVariables.ConnectionString;
        }

        public static string GetLogsErrorMessage;
        public static bool GetLogsSuccessful;
        public static DataTable GetLogs(DateTime _date_from, DateTime _date_to)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_entrance_logs_get", con);
                    cmd.Parameters.Add(new MySqlParameter("_date_from", _date_from));
                    cmd.Parameters.Add(new MySqlParameter("_date_to", _date_to));
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    GetLogsSuccessful = true;
                    return dt;
                }
            }
            catch (Exception ex)
            {
                GetLogsSuccessful = false;
                GetLogsErrorMessage = ex.Message + "\nFunction : Get Entrance Logs";
                return null;
            }
        }

        public static string LogsAddErrorMessage;
        public static bool LogsAddSuccessful;
        public static void LogsAdd(int _registered_borrower_id, string _type)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_entrance_logs_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_registered_borrower_id", _registered_borrower_id));
                    cmd.Parameters.Add(new MySqlParameter("_type", _type));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LogsAddSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                LogsAddSuccessful = false;
                LogsAddErrorMessage = ex.Message + "\nFunction : Entrance Logs Add";
            }
        }
    }
}
