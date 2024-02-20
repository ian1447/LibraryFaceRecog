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

        public static string BooksAddErrorMessage;
        public static bool BooksAddSuccessful;
        public static void BooksAdd(string _title, string _author, string _place_and_publisher, string _section, string _call_no, string _account_no, int _no_of_copies, string _edition, double _cost_price, string _copyright_year, string _type)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_books_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_title", _title));
                    cmd.Parameters.Add(new MySqlParameter("_author", _author));
                    cmd.Parameters.Add(new MySqlParameter("_place_and_publisher", _place_and_publisher));
                    cmd.Parameters.Add(new MySqlParameter("_section", _section));
                    cmd.Parameters.Add(new MySqlParameter("_call_no", _call_no));
                    cmd.Parameters.Add(new MySqlParameter("_account_no", _account_no));
                    cmd.Parameters.Add(new MySqlParameter("_no_of_copies", _no_of_copies));
                    cmd.Parameters.Add(new MySqlParameter("_edition", _edition));
                    cmd.Parameters.Add(new MySqlParameter("_cost_price", _cost_price));
                    cmd.Parameters.Add(new MySqlParameter("_copyright_year", _copyright_year));
                    cmd.Parameters.Add(new MySqlParameter("_type", _type));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BooksAddSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                BooksAddSuccessful = false;
                BooksAddErrorMessage = ex.Message + "\nFunction : Add Book";
            }
        }

        public static string BookEditErrorMessage;
        public static bool BookEditSuccessful;
        public static void BookEdit(string _title, string _author, string _place_and_publisher, string _section, string _call_no, string _account_no, int _no_of_copies, string _edition, double _cost_price, string _copyright_year, int _edit_id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_books_edit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_title", _title));
                    cmd.Parameters.Add(new MySqlParameter("_author", _author));
                    cmd.Parameters.Add(new MySqlParameter("_place_and_publisher", _place_and_publisher));
                    cmd.Parameters.Add(new MySqlParameter("_section", _section));
                    cmd.Parameters.Add(new MySqlParameter("_call_no", _call_no));
                    cmd.Parameters.Add(new MySqlParameter("_account_no", _account_no));
                    cmd.Parameters.Add(new MySqlParameter("_no_of_copies", _no_of_copies));
                    cmd.Parameters.Add(new MySqlParameter("_edition", _edition));
                    cmd.Parameters.Add(new MySqlParameter("_cost_price", _cost_price));
                    cmd.Parameters.Add(new MySqlParameter("_copyright_year", _copyright_year));
                    cmd.Parameters.Add(new MySqlParameter("_edit_id", _edit_id));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BookEditSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                BookEditSuccessful = false;
                BookEditErrorMessage = ex.Message + "\nFunction : Edit Book";
            }
        }

        public static string BookDeacErrorMessage;
        public static bool BookDeacSuccessful;
        public static void BookDeac(int _id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_book_deac", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_id", _id));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BookDeacSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                BookDeacSuccessful = false;
                BookDeacErrorMessage = ex.Message + "\nFunction : Deac Book";
            }
        }

        public static string SearchBooksErrorMessage;
        public static bool SearchBooksSuccessful;
        public static DataTable SearchBooks(string _title)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_books_search", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_title", _title));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    SearchBooksSuccessful = true;
                    return dt;
                }
            }
            catch (Exception ex)
            {
                SearchBooksSuccessful = false;
                SearchBooksErrorMessage = ex.Message + "\nFunction : Search Books";
                return null;
            }
        }
    }
}
