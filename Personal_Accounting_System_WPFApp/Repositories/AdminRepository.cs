using Personal_Accounting_System_WPFApp.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Personal_Accounting_System_WPFApp.Repositories
{
    class AdminRepository
    {
        public void DisableUser(UserDto user)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };
                
            try
            {
                conn.Open();
                Console.WriteLine("Database Connected");

                SqlCommand command = new SqlCommand("UPDATE Users SET DisableTime = @date Where UserId = @userId", conn);
                command.Parameters.AddWithValue("@date", user.DisableTime);
                command.Parameters.AddWithValue("@userId", user.UserId);
                command.ExecuteNonQuery();
                Console.WriteLine("Data Stored Into Database");
                conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ModifyUser(UserDto user, int userId)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                conn.Open();
                Console.WriteLine("Database Connected");

                string query = $"UPDATE Users SET Name = '{user.Name}', DateOfBirth = {user.DateOfBirth}, Email = '{user.Email}' WHERE UserId = {userId}";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data Stored Into Database");
                conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
