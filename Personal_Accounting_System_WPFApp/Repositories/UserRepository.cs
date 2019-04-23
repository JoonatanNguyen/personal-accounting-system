using Personal_Accounting_System_WPFApp.Dtos;
using System;
using System.Data.SqlClient;

namespace Personal_Accounting_System_WPFApp.Repositories
{
    class UserRepository
    {
        public void RegisterUser(UserDto user, string hash)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                conn.Open(); 
                Console.WriteLine("Database Connected");
                
                string query = $"INSERT INTO Users (Name, DateOfBirth, Email, Password) " +
                    $"VALUES ('{user.Name}', '{user.DateOfBirth}', '{user.Email}', '{hash}')";
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

        public string GetHash(string email)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                conn.Open();
                Console.WriteLine("Database Connected");
                string query = $"SELECT Password from Users WHERE Email = '{email}'";
                SqlCommand command = new SqlCommand(query, conn);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader["Password"]?.ToString();
                    }
                }
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }

            return "";
        }

        public bool IsEmailAvailable(string email)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                conn.Open();
                Console.WriteLine("Database Connected");
                string query = $"SELECT UserId from Users WHERE Email = '{email}'";
                SqlCommand command = new SqlCommand(query, conn);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return false;
                    }
                }
                conn.Close();
                return true;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public int GetUserId(string email)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                conn.Open();
                Console.WriteLine("Database Connected");
                string query = $"SELECT UserId from Users WHERE Email = '{email}'";
                SqlCommand command = new SqlCommand(query, conn);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return int.Parse(reader["UserId"]?.ToString() ?? "0");
                    }
                }
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }

            return 0;
        }


    }
}
