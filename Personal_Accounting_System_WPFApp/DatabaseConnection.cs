using System;
using System.Data.SqlClient;

namespace Personal_Accounting_System_WPFApp
{
    class DatabaseConnection
    {
        //public void Insert(string query)
        //{
        //    var conn = new SqlConnection { ConnectionString = "Server=localhost\\SQLEXPRESS;Database=PersonalAccountingSystem;Trusted_Connection=True" };

        //    try
        //    {
        //        conn.Open();
        //        Console.WriteLine("Database Connected");
        //        SqlCommand insert = new SqlCommand(query, conn);
        //        insert.ExecuteNonQuery();
        //        Console.WriteLine("Data Stored Into Database");
        //        conn.Close();
        //    }
        //    catch (SqlException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}
        //public string Select(string query)
        //{
        //    var conn = new SqlConnection { ConnectionString = "Server=localhost\\SQLEXPRESS;Database=PersonalAccountingSystem;Trusted_Connection=True" };

        //    try
        //    {
        //        conn.Open();
        //        Console.WriteLine("Database Connected");
        //        SqlCommand select = new SqlCommand(query, conn);
        //        using (var reader = select.ExecuteReader())
        //            while (reader.Read())
        //            {
        //                return reader["Password"]?.ToString();
        //            }
        //        conn.Close();
        //    }
        //    catch (SqlException e)
        //    { 
        //        throw e;
        //    }
        //}
    }
}
