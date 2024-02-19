using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryFaceRecog.Core;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibraryFaceRecog.Dal
{
    public class Borrower
    {
        private static string ConnectionString()
        {
            return PublicVariables.ConnectionString;
        }

        public static string GetBorrowedBooksErrorMessage;
        public static bool GetBorrowedBooksSuccessful;
        public static DataTable GetBorrowedBooks(DateTime _date_from, DateTime _date_to)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_book_borrow_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_type", PublicVariables.AccountType));
                    cmd.Parameters.Add(new MySqlParameter("_date_from", _date_from));
                    cmd.Parameters.Add(new MySqlParameter("_date_to", _date_to));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    GetBorrowedBooksSuccessful = true;
                    return dt;
                }
            }
            catch (Exception ex)
            {
                GetBorrowedBooksSuccessful = false;
                GetBorrowedBooksErrorMessage = ex.Message + "\nFunction : Get Borrowed Books";
                return null;
            }
        }

        public static string GetBorrowedBooksbyBorrowerErrorMessage;
        public static bool GetBorrowedBooksbyBorrowerSuccessful;
        public static DataTable GetBorrowedBooksbyBorrower(int _id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_borrowed_books_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_id", _id));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    GetBorrowedBooksbyBorrowerSuccessful = true;
                    return dt;
                }
            }
            catch (Exception ex)
            {
                GetBorrowedBooksbyBorrowerSuccessful = false;
                GetBorrowedBooksbyBorrowerErrorMessage = ex.Message + "\nFunction : Get Borrowed Books From Borrower";
                return null;
            }
        }

        public static string BorrowBookErrorMessage;
        public static bool BorrowBookSuccessful;
        public static void BorrowBook(int _book_id, int _borrower_id, string _barcode)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_borrow_book", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_book_id", _book_id));
                    cmd.Parameters.Add(new MySqlParameter("_borrower_id", _borrower_id));
                    cmd.Parameters.Add(new MySqlParameter("_barcode", _barcode));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BorrowBookSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                BorrowBookSuccessful = false;
                BorrowBookErrorMessage = ex.Message + "\nFunction : Borrow Book";
            }
        }

        public static string ReturnBookErrorMessage;
        public static bool ReturnBookSuccessful;
        public static void ReturnBook(string _barcode)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_return_book", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_barcode", _barcode));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ReturnBookSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                ReturnBookSuccessful = false;
                ReturnBookErrorMessage = ex.Message + "\nFunction : Return Book";
            }
        }
    }
}
