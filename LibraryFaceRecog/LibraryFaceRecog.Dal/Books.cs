using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryFaceRecog.Core;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibraryFaceRecog.Dal
{
    public class Books
    {
        private static string ConnectionString()
        {
            return PublicVariables.ConnectionString;
        }

        public static string GetBooksErrorMessage;
        public static bool GetBooksSuccessful;
        public static DataTable GetBooks(string _type)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_books_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_type", _type));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    GetBooksSuccessful = true;
                    return dt;
                }
            }
            catch (Exception ex)
            {
                GetBooksSuccessful = false;
                GetBooksErrorMessage = ex.Message + "\nFunction : Get Registered Books";
                return null;
            }
        }
    }
}
