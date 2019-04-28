using Personal_Accounting_System_WPFApp.Dtos;
using System;
using System.Data.SqlClient;


namespace Personal_Accounting_System_WPFApp.Repositories
{
    class AccountRepository
    {
        public void CreatAccount(AccountDto account)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                string query = "";
                conn.Open();
                Console.WriteLine("Database Connected");

                if (account.OtherEntitiesId.HasValue)
                {
                    query = $"INSERT INTO Accounts (OwnerUsers, OtherOwnerEntities) " +
                        $"VALUES (NULL,  {account.OtherEntitiesId})";
                } else
                {
                    query = $"INSERT INTO Accounts (OwnerUsers, OtherOwnerEntities) " +
                        $"VALUES ({account.UserId},  NULL)";
                }
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data Stored Into Database");
                conn.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int GetAccountId(int userId)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                conn.Open();
                Console.WriteLine("Database Connected");
                string query = $@"select Accounts.OwnerUsers from Accounts 
                                    inner join Users on Accounts.OwnerUsers = Users.UserId
                                    Where Users.UserId = {userId}";
                SqlCommand command = new SqlCommand(query, conn);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return int.Parse(reader["OwnerUsers"]?.ToString() ?? "0");
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
