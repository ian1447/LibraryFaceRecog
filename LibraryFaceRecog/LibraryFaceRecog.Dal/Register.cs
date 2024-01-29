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
        public static DataTable GetRegisteredBorrowers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_registered_borrowers_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
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
    }
}
